using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApplication.Migrations
{
    /// <inheritdoc />
    public partial class UpdateManyToManyModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SongContributers");

            migrationBuilder.CreateTable(
                name: "MediaContributers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    MediaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaContributers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaContributers_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaContributers_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PodcastContributer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    PodcastId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastContributer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PodcastContributer_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PodcastContributer_MediaCollection_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "MediaCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaContributers_ArtistId",
                table: "MediaContributers",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaContributers_MediaId",
                table: "MediaContributers",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastContributer_ArtistId",
                table: "PodcastContributer",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastContributer_PodcastId",
                table: "PodcastContributer",
                column: "PodcastId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaContributers");

            migrationBuilder.DropTable(
                name: "PodcastContributer");

            migrationBuilder.CreateTable(
                name: "SongContributers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    SongId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongContributers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SongContributers_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongContributers_Media_SongId",
                        column: x => x.SongId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SongContributers_ArtistId",
                table: "SongContributers",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_SongContributers_SongId",
                table: "SongContributers",
                column: "SongId");
        }
    }
}
