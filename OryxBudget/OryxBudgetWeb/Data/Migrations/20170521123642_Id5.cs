using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OryxBudgetWeb.Data.Migrations
{
    public partial class Id5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Final",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MalCom",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SubCom",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TecCom",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Final",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MalCom",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SubCom",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TecCom",
                table: "AspNetUsers");
        }
    }
}
