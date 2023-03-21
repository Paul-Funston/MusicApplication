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
            modelBuilder.Entity<Song>()
                .ToTable(s => s.HasCheckConstraint("CK_Duration", "[DurationSeconds] > 0"))
                .ToTable(s => s.HasCheckConstraint("CK_TrackNumber", "[TrackNumber]> 0"));

            modelBuilder.Entity<Song>()
                .HasIndex(s => new { s.AlbumId, s.TrackNumber })
                .IsUnique();


        }
        public DbSet<MusicApplication.Models.Song> Songs { get; set; } = default!;
        public DbSet<MusicApplication.Models.Album> Albums { get; set; } = default!;
        public DbSet<MusicApplication.Models.Artist> Artists{ get; set; } = default!;
        public DbSet<MusicApplication.Models.Playlist> Playlists{ get; set; } = default!;
        public DbSet<MusicApplication.Models.PlaylistSong> PlaylistSongs { get; set; } = default!;
        public DbSet<MusicApplication.Models.SongContributer> SongContributers { get; set; } = default!;
    }
}
