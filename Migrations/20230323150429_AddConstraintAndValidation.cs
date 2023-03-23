using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddConstraintAndValidation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListenerListPodcast_ListenerLists_ListenerListId",
                table: "ListenerListPodcast");

            migrationBuilder.DropForeignKey(
                name: "FK_ListenerListPodcast_MediaCollection_PodcastId",
                table: "ListenerListPodcast");

            migrationBuilder.DropForeignKey(
                name: "FK_PodcastContributer_Artists_ArtistId",
                table: "PodcastContributer");

            migrationBuilder.DropForeignKey(
                name: "FK_PodcastContributer_MediaCollection_PodcastId",
                table: "PodcastContributer");

            migrationBuilder.DropIndex(
                name: "IX_PlaylistSongs_SongId",
                table: "PlaylistSongs");

            migrationBuilder.DropIndex(
                name: "IX_MediaContributers_MediaId",
                table: "MediaContributers");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Duration",
                table: "Media");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PodcastContributer",
                table: "PodcastContributer");

            migrationBuilder.DropIndex(
                name: "IX_PodcastContributer_ArtistId",
                table: "PodcastContributer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListenerListPodcast",
                table: "ListenerListPodcast");

            migrationBuilder.DropIndex(
                name: "IX_ListenerListPodcast_ListenerListId",
                table: "ListenerListPodcast");

            migrationBuilder.RenameTable(
                name: "PodcastContributer",
                newName: "PodcastContributers");

            migrationBuilder.RenameTable(
                name: "ListenerListPodcast",
                newName: "ListenerListPodcasts");

            migrationBuilder.RenameIndex(
                name: "IX_PodcastContributer_PodcastId",
                table: "PodcastContributers",
                newName: "IX_PodcastContributers_PodcastId");

            migrationBuilder.RenameIndex(
                name: "IX_ListenerListPodcast_PodcastId",
                table: "ListenerListPodcasts",
                newName: "IX_ListenerListPodcasts_PodcastId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Playlists",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "MediaCollection",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Media",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Media",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ListenerLists",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Artists",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PodcastContributers",
                table: "PodcastContributers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListenerListPodcasts",
                table: "ListenerListPodcasts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistSongs_SongId_PlaylistId",
                table: "PlaylistSongs",
                columns: new[] { "SongId", "PlaylistId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaContributers_MediaId_ArtistId",
                table: "MediaContributers",
                columns: new[] { "MediaId", "ArtistId" },
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Duration",
                table: "Media",
                sql: "[DurationSeconds] > 0 AND [DurationSeconds] < 86400");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastContributers_ArtistId_PodcastId",
                table: "PodcastContributers",
                columns: new[] { "ArtistId", "PodcastId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListenerListPodcasts_ListenerListId_PodcastId",
                table: "ListenerListPodcasts",
                columns: new[] { "ListenerListId", "PodcastId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ListenerListPodcasts_ListenerLists_ListenerListId",
                table: "ListenerListPodcasts",
                column: "ListenerListId",
                principalTable: "ListenerLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListenerListPodcasts_MediaCollection_PodcastId",
                table: "ListenerListPodcasts",
                column: "PodcastId",
                principalTable: "MediaCollection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PodcastContributers_Artists_ArtistId",
                table: "PodcastContributers",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PodcastContributers_MediaCollection_PodcastId",
                table: "PodcastContributers",
                column: "PodcastId",
                principalTable: "MediaCollection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListenerListPodcasts_ListenerLists_ListenerListId",
                table: "ListenerListPodcasts");

            migrationBuilder.DropForeignKey(
                name: "FK_ListenerListPodcasts_MediaCollection_PodcastId",
                table: "ListenerListPodcasts");

            migrationBuilder.DropForeignKey(
                name: "FK_PodcastContributers_Artists_ArtistId",
                table: "PodcastContributers");

            migrationBuilder.DropForeignKey(
                name: "FK_PodcastContributers_MediaCollection_PodcastId",
                table: "PodcastContributers");

            migrationBuilder.DropIndex(
                name: "IX_PlaylistSongs_SongId_PlaylistId",
                table: "PlaylistSongs");

            migrationBuilder.DropIndex(
                name: "IX_MediaContributers_MediaId_ArtistId",
                table: "MediaContributers");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Duration",
                table: "Media");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PodcastContributers",
                table: "PodcastContributers");

            migrationBuilder.DropIndex(
                name: "IX_PodcastContributers_ArtistId_PodcastId",
                table: "PodcastContributers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListenerListPodcasts",
                table: "ListenerListPodcasts");

            migrationBuilder.DropIndex(
                name: "IX_ListenerListPodcasts_ListenerListId_PodcastId",
                table: "ListenerListPodcasts");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Media");

            migrationBuilder.RenameTable(
                name: "PodcastContributers",
                newName: "PodcastContributer");

            migrationBuilder.RenameTable(
                name: "ListenerListPodcasts",
                newName: "ListenerListPodcast");

            migrationBuilder.RenameIndex(
                name: "IX_PodcastContributers_PodcastId",
                table: "PodcastContributer",
                newName: "IX_PodcastContributer_PodcastId");

            migrationBuilder.RenameIndex(
                name: "IX_ListenerListPodcasts_PodcastId",
                table: "ListenerListPodcast",
                newName: "IX_ListenerListPodcast_PodcastId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Playlists",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "MediaCollection",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Media",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ListenerLists",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PodcastContributer",
                table: "PodcastContributer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListenerListPodcast",
                table: "ListenerListPodcast",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistSongs_SongId",
                table: "PlaylistSongs",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaContributers_MediaId",
                table: "MediaContributers",
                column: "MediaId");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Duration",
                table: "Media",
                sql: "[DurationSeconds] > 0");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastContributer_ArtistId",
                table: "PodcastContributer",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ListenerListPodcast_ListenerListId",
                table: "ListenerListPodcast",
                column: "ListenerListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListenerListPodcast_ListenerLists_ListenerListId",
                table: "ListenerListPodcast",
                column: "ListenerListId",
                principalTable: "ListenerLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListenerListPodcast_MediaCollection_PodcastId",
                table: "ListenerListPodcast",
                column: "PodcastId",
                principalTable: "MediaCollection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PodcastContributer_Artists_ArtistId",
                table: "PodcastContributer",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PodcastContributer_MediaCollection_PodcastId",
                table: "PodcastContributer",
                column: "PodcastId",
                principalTable: "MediaCollection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
