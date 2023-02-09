using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace azimzada.com.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMoodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Input",
                table: "Demos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Input",
                table: "Demos");
        }
    }
}
