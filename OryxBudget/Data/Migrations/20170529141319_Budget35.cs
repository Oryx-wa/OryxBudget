using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Budget35 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BudgetId",
                table: "StatusHistoryLog",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "StatusHistoryLog",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemCodeStatus",
                table: "StatusHistoryLog",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "BudgetId",
                table: "StatusHistory",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "StatusHistory",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemCodeStatus",
                table: "StatusHistory",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BudgetId",
                table: "StatusHistoryLog");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "StatusHistoryLog");

            migrationBuilder.DropColumn(
                name: "ItemCodeStatus",
                table: "StatusHistoryLog");

            migrationBuilder.DropColumn(
                name: "BudgetId",
                table: "StatusHistory");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "StatusHistory");

            migrationBuilder.DropColumn(
                name: "ItemCodeStatus",
                table: "StatusHistory");
        }
    }
}
