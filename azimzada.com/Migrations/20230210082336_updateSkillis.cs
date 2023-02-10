using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace azimzada.com.Migrations
{
    /// <inheritdoc />
    public partial class updateSkillis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Skillis",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Skillis");
        }
    }
}
