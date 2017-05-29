using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Budget37 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusHistoryLog",
                table: "StatusHistoryLog");

            migrationBuilder.RenameTable(
                name: "StatusHistoryLog",
                newName: "StatusHistoryLogs");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "StatusHistory",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusHistoryLogs",
                table: "StatusHistoryLogs",
                columns: new[] { "Id", "LogInstance" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusHistoryLogs",
                table: "StatusHistoryLogs");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "StatusHistory");

            migrationBuilder.RenameTable(
                name: "StatusHistoryLogs",
                newName: "StatusHistoryLog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusHistoryLog",
                table: "StatusHistoryLog",
                columns: new[] { "Id", "LogInstance" });
        }
    }
}
