using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApplication.Migrations
{
    /// <inheritdoc />
    public partial class DefineRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListenerLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListenerLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListenerListPodcast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListenerListId = table.Column<int>(type: "int", nullable: false),
                    PodcastId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListenerListPodcast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListenerListPodcast_ListenerLists_ListenerListId",
                        column: x => x.ListenerListId,
                        principalTable: "ListenerLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListenerListPodcast_MediaCollection_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "MediaCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListenerListPodcast_ListenerListId",
                table: "ListenerListPodcast",
                column: "ListenerListId");

            migrationBuilder.CreateIndex(
                name: "IX_ListenerListPodcast_PodcastId",
                table: "ListenerListPodcast",
                column: "PodcastId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListenerListPodcast");

            migrationBuilder.DropTable(
                name: "ListenerLists");
        }
    }
}
