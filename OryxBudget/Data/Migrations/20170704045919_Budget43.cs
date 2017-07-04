using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Budget43 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatus",
                table: "StatusHistoryLogs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatus",
                table: "StatusHistory",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                table: "StatusHistoryLogs");

            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                table: "StatusHistory");
        }
    }
}
