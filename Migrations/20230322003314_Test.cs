using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicApplication.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_TrackNumber",
                table: "Media");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_TrackNumber",
                table: "Media",
                sql: "[CollectionOrderNumber]> 0");
        }
    }
}
