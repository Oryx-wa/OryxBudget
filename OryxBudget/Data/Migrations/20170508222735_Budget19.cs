using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Budget19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageSrc",
                table: "OperatorLogs",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageSrc",
                table: "Operators",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageSrc",
                table: "OperatorLogs");

            migrationBuilder.DropColumn(
                name: "ImageSrc",
                table: "Operators");
        }
    }
}
