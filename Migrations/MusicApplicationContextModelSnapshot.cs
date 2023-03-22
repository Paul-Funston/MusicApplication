﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicApplication.Data;

#nullable disable

namespace MusicApplication.Migrations
{
    [DbContext(typeof(MusicApplicationContext))]
    partial class MusicApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MusicApplication.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("MusicApplication.Models.Media", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CollectionOrderNumber")
                        .HasColumnType("int");

                    b.Property<int>("DurationSeconds")
                        .HasColumnType("int");

                    b.Property<int>("MediaCollectionId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("media_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MediaCollectionId", "CollectionOrderNumber")
                        .IsUnique();

                    b.ToTable("Media", t =>
                        {
                            t.HasCheckConstraint("CK_CollectionOrderNumber", "[CollectionOrderNumber] > 0");

                            t.HasCheckConstraint("CK_Duration", "[DurationSeconds] > 0");
                        });

                    b.HasDiscriminator<string>("media_type").HasValue("Media");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MusicApplication.Models.MediaCollection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("collection_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MediaCollection");

                    b.HasDiscriminator<string>("collection_type").HasValue("MediaCollection");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MusicApplication.Models.MediaContributer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("MediaId");

                    b.ToTable("MediaContributers");
                });

            modelBuilder.Entity("MusicApplication.Models.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("MusicApplication.Models.PlaylistSong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PlaylistId")
                        .HasColumnType("int");

                    b.Property<int>("SongId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeAdded")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PlaylistId");

                    b.HasIndex("SongId");

                    b.ToTable("PlaylistSongs");
                });

            modelBuilder.Entity("MusicApplication.Models.PodcastContributer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int>("PodcastId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("PodcastId");

                    b.ToTable("PodcastContributer");
                });

            modelBuilder.Entity("MusicApplication.Models.Episode", b =>
                {
                    b.HasBaseType("MusicApplication.Models.Media");

                    b.ToTable(t =>
                        {
                            t.HasCheckConstraint("CK_CollectionOrderNumber", "[CollectionOrderNumber] > 0");

                            t.HasCheckConstraint("CK_Duration", "[DurationSeconds] > 0");
                        });

                    b.HasDiscriminator().HasValue("media_episode");
                });

            modelBuilder.Entity("MusicApplication.Models.Song", b =>
                {
                    b.HasBaseType("MusicApplication.Models.Media");

                    b.ToTable(t =>
                        {
                            t.HasCheckConstraint("CK_CollectionOrderNumber", "[CollectionOrderNumber] > 0");

                            t.HasCheckConstraint("CK_Duration", "[DurationSeconds] > 0");
                        });

                    b.HasDiscriminator().HasValue("media_song");
                });

            modelBuilder.Entity("MusicApplication.Models.Album", b =>
                {
                    b.HasBaseType("MusicApplication.Models.MediaCollection");

                    b.HasDiscriminator().HasValue("collection_album");
                });

            modelBuilder.Entity("MusicApplication.Models.Podcast", b =>
                {
                    b.HasBaseType("MusicApplication.Models.MediaCollection");

                    b.HasDiscriminator().HasValue("collection_podcast");
                });

            modelBuilder.Entity("MusicApplication.Models.MediaContributer", b =>
                {
                    b.HasOne("MusicApplication.Models.Artist", "Artist")
                        .WithMany("SongContributers")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicApplication.Models.Media", "Media")
                        .WithMany("MediaContributers")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Media");
                });

            modelBuilder.Entity("MusicApplication.Models.PlaylistSong", b =>
                {
                    b.HasOne("MusicApplication.Models.Playlist", "Playlist")
                        .WithMany("PlaylistSongs")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicApplication.Models.Song", "Song")
                        .WithMany("PlaylistSongs")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Playlist");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("MusicApplication.Models.PodcastContributer", b =>
                {
                    b.HasOne("MusicApplication.Models.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicApplication.Models.Podcast", "Podcast")
                        .WithMany("Cast")
                        .HasForeignKey("PodcastId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Podcast");
                });

            modelBuilder.Entity("MusicApplication.Models.Episode", b =>
                {
                    b.HasOne("MusicApplication.Models.Podcast", "Podcast")
                        .WithMany("Episodes")
                        .HasForeignKey("MediaCollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Podcast");
                });

            modelBuilder.Entity("MusicApplication.Models.Song", b =>
                {
                    b.HasOne("MusicApplication.Models.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("MediaCollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("MusicApplication.Models.Artist", b =>
                {
                    b.Navigation("SongContributers");
                });

            modelBuilder.Entity("MusicApplication.Models.Media", b =>
                {
                    b.Navigation("MediaContributers");
                });

            modelBuilder.Entity("MusicApplication.Models.Playlist", b =>
                {
                    b.Navigation("PlaylistSongs");
                });

            modelBuilder.Entity("MusicApplication.Models.Song", b =>
                {
                    b.Navigation("PlaylistSongs");
                });

            modelBuilder.Entity("MusicApplication.Models.Album", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("MusicApplication.Models.Podcast", b =>
                {
                    b.Navigation("Cast");

                    b.Navigation("Episodes");
                });
#pragma warning restore 612, 618
        }
    }
}
