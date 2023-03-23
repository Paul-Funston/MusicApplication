using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicApplication.Models;

namespace MusicApplication.Data
{
    public class MusicApplicationContext : DbContext
    {
        public MusicApplicationContext (DbContextOptions<MusicApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            
            _modelCreateRelationships(modelBuilder);
            
            _modelCreateValidation(modelBuilder);


        }

        private void _modelCreateRelationships(ModelBuilder modelBuilder)
        {
            
            // Media and Media Collections
            modelBuilder.Entity<MediaCollection>()
                .HasDiscriminator<string>("collection_type")
                .HasValue<Album>("collection_album")
                .HasValue<Podcast>("collection_podcast");

            modelBuilder.Entity<Album>()
                .HasMany(a => a.Songs)
                .WithOne(s => s.Album)
                .HasForeignKey(s => s.MediaCollectionId);

            modelBuilder.Entity<Podcast>()
                .HasMany(p => p.Episodes)
                .WithOne(e => e.Podcast)
                .HasForeignKey(e => e.MediaCollectionId);


            modelBuilder.Entity<Media>()
                .HasDiscriminator<string>("media_type")
                .HasValue<Song>("media_song")
                .HasValue<Episode>("media_episode");


            // Artists to Media and Podcasts

            modelBuilder.Entity<Podcast>()
                .HasMany(p => p.Cast)
                .WithOne(c => c.Podcast)
                .HasForeignKey(pc => pc.PodcastId);

            modelBuilder.Entity<Artist>()
                .HasMany(a => a.PodcastContributers)
                .WithOne(pc => pc.Artist)
                .HasForeignKey(pc => pc.ArtistId);

            modelBuilder.Entity<Media>()
                .HasMany(s => s.MediaContributers)
                .WithOne(mc => mc.Media)
                .HasForeignKey(mc => mc.MediaId);

            modelBuilder.Entity<Artist>()
                .HasMany(a => a.MediaContributers)
                .WithOne(mc => mc.Artist)
                .HasForeignKey(mc => mc.ArtistId);


            // Songs and Playlists, Podcasts and ListenerLists

            modelBuilder.Entity<Song>()
                .HasMany(s => s.PlaylistSongs)
                .WithOne(ps => ps.Song)
                .HasForeignKey(ps => ps.SongId);

            modelBuilder.Entity<Playlist>()
                .HasMany(p => p.PlaylistSongs)
                .WithOne(ps => ps.Playlist)
                .HasForeignKey(ps => ps.PlaylistId);

            modelBuilder.Entity<Podcast>()
                .HasMany(p => p.ListenerListPodcasts)
                .WithOne(c => c.Podcast)
                .HasForeignKey(c => c.PodcastId);

            modelBuilder.Entity<ListenerList>()
                .HasMany(ll => ll.ListenerListPodcasts)
                .WithOne(llp => llp.ListenerList)
                .HasForeignKey(llp => llp.ListenerListId);

        }



        private void _modelCreateValidation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Media>(entity =>
            {
                entity.HasIndex(e => new { e.MediaCollectionId, e.CollectionOrderNumber })
                    .IsUnique();

                entity.ToTable(e =>
                    e.HasCheckConstraint("CK_Duration", 
                    "[DurationSeconds] > 0 AND [DurationSeconds] < 86400"));
                
                entity.ToTable(e => 
                    e.HasCheckConstraint("CK_CollectionOrderNumber", "[CollectionOrderNumber] > 0"));

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CollectionOrderNumber)
                    .IsRequired();

                entity.Property(e => e.DurationSeconds)
                    .IsRequired();
            });

            modelBuilder.Entity<Episode>(entity =>
            {
                entity.Property(e => e.ReleaseDate)
                    .IsRequired();
            });

            modelBuilder.Entity<MediaCollection>(entity =>
            {
                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsRequired();
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired();
            });


            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired();
            });

            modelBuilder.Entity<ListenerList>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired();
            });



            
            modelBuilder.Entity<MediaContributer>(entity =>
            {
                entity.HasIndex(e => new { e.MediaId, e.ArtistId })
                    .IsUnique();
            });

            modelBuilder.Entity<PodcastContributer>(entity =>
            {
                entity.HasIndex(e => new { e.ArtistId, e.PodcastId})
                    .IsUnique();
            });

            modelBuilder.Entity<PlaylistSong>(entity =>
            {
                entity.HasIndex(e => new { e.SongId, e.PlaylistId})
                    .IsUnique();
            });

            

            modelBuilder.Entity<ListenerListPodcast>(entity =>
            {
                entity.HasIndex(e => new { e.ListenerListId, e.PodcastId})
                    .IsUnique();
            });
        }

        public DbSet<MusicApplication.Models.Song> Songs { get; set; } = default!;
        public DbSet<Episode> Episodes { get; set; } = default!;
        public DbSet<MusicApplication.Models.Album> Albums { get; set; } = default!;
        public DbSet<Podcast> Podcasts { get; set; } = default!;
        public DbSet<MusicApplication.Models.Artist> Artists{ get; set; } = default!;
        public DbSet<MusicApplication.Models.Playlist> Playlists{ get; set; } = default!;
        public DbSet<MusicApplication.Models.PlaylistSong> PlaylistSongs { get; set; } = default!;
        public DbSet<MusicApplication.Models.MediaContributer> MediaContributers { get; set; } = default!;
        public DbSet<PodcastContributer> PodcastContributers { get; set; } = default!;
        public DbSet<ListenerList> ListenerLists { get; set; } = default!;
        public DbSet<ListenerListPodcast> ListenerListPodcasts { get; set; } = default!;


    }
}
