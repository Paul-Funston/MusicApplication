using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddInheritanceModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSongs_Songs_SongId",
                table: "PlaylistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_SongContributers_Songs_SongId",
                table: "SongContributers");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Songs",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_AlbumId",
                table: "Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Albums",
                table: "Albums");

            migrationBuilder.RenameTable(
                name: "Songs",
                newName: "Media");

            migrationBuilder.RenameTable(
                name: "Albums",
                newName: "MediaCollection");

            migrationBuilder.RenameColumn(
                name: "AlbumId",
                table: "Media",
                newName: "MediaCollectionId");

            migrationBuilder.AddColumn<int>(
                name: "CollectionOrderNumber",
                table: "Media",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "media_type",
                table: "Media",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "collection_type",
                table: "MediaCollection",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Media",
                table: "Media",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MediaCollection",
                table: "MediaCollection",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Media_MediaCollectionId_CollectionOrderNumber",
                table: "Media",
                columns: new[] { "MediaCollectionId", "CollectionOrderNumber" },
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Duration",
                table: "Media",
                sql: "[DurationSeconds] > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_TrackNumber",
                table: "Media",
                sql: "[CollectionOrderNumber] > 0");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_MediaCollection_MediaCollectionId",
                table: "Media",
                column: "MediaCollectionId",
                principalTable: "MediaCollection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSongs_Media_SongId",
                table: "PlaylistSongs",
                column: "SongId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongContributers_Media_SongId",
                table: "SongContributers",
                column: "SongId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_MediaCollection_MediaCollectionId",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSongs_Media_SongId",
                table: "PlaylistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_SongContributers_Media_SongId",
                table: "SongContributers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MediaCollection",
                table: "MediaCollection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Media",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_MediaCollectionId_CollectionOrderNumber",
                table: "Media");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Duration",
                table: "Media");

            migrationBuilder.DropCheckConstraint(
                name: "CK_TrackNumber",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "collection_type",
                table: "MediaCollection");

            migrationBuilder.DropColumn(
                name: "CollectionOrderNumber",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "media_type",
                table: "Media");

            migrationBuilder.RenameTable(
                name: "MediaCollection",
                newName: "Albums");

            migrationBuilder.RenameTable(
                name: "Media",
                newName: "Songs");

            migrationBuilder.RenameColumn(
                name: "MediaCollectionId",
                table: "Songs",
                newName: "AlbumId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Albums",
                table: "Albums",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Songs",
                table: "Songs",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumId",
                table: "Songs",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSongs_Songs_SongId",
                table: "PlaylistSongs",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongContributers_Songs_SongId",
                table: "SongContributers",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
