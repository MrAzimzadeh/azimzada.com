﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace azimzada.com.Migrations
{
    /// <inheritdoc />
    public partial class updateSkillis2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Skillis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Skillis");
        }
    }
}
