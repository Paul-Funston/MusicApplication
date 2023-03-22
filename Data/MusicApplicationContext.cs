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
            modelBuilder.Entity<Media>()
                .HasDiscriminator<string>("media_type")
                .HasValue<Song>("media_song")
                .HasValue<Episode>("media_episode");

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


            
        }



        private void _modelCreateValidation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Media>()
                .ToTable(m => m.HasCheckConstraint("CK_Duration", "[DurationSeconds] > 0"))
                .ToTable(m => m.HasCheckConstraint("CK_CollectionOrderNumber", "[CollectionOrderNumber] > 0"));

            modelBuilder.Entity<Media>()
                .HasIndex(m => new { m.MediaCollectionId, m.CollectionOrderNumber })
                .IsUnique();

        }
        public DbSet<MusicApplication.Models.Song> Songs { get; set; } = default!;
        public DbSet<Episode> Episodes { get; set; } = default!;
        public DbSet<MusicApplication.Models.Album> Albums { get; set; } = default!;
        public DbSet<MusicApplication.Models.Artist> Artists{ get; set; } = default!;
        public DbSet<MusicApplication.Models.Playlist> Playlists{ get; set; } = default!;
        public DbSet<MusicApplication.Models.PlaylistSong> PlaylistSongs { get; set; } = default!;
        public DbSet<MusicApplication.Models.MediaContributer> MediaContributers { get; set; } = default!;
    }
}
