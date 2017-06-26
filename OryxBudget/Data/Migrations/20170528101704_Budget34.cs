using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Budget34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "LineCommentLog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "LineCommentLog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "LineComment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "LineComment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "LineCommentLog");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "LineCommentLog");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "LineComment");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "LineComment");
        }
    }
}
