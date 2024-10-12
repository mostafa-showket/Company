﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureName",
                table: "Employees");
        }
    }
}
