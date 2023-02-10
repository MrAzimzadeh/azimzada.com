using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace azimzada.com.Migrations
{
    /// <inheritdoc />
    public partial class initiala : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimatedTexts",
                table: "AnimatedTexts");

            migrationBuilder.RenameTable(
                name: "AnimatedTexts",
                newName: "AnimatedText");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimatedText",
                table: "AnimatedText",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimatedText",
                table: "AnimatedText");

            migrationBuilder.RenameTable(
                name: "AnimatedText",
                newName: "AnimatedTexts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimatedTexts",
                table: "AnimatedTexts",
                column: "Id");
        }
    }
}
