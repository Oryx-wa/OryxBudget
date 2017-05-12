using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Budget20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Level1",
                table: "BudgetCodeLogs",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level2",
                table: "BudgetCodeLogs",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level1",
                table: "BudgetCodes",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level2",
                table: "BudgetCodes",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level1",
                table: "BudgetCodeLogs");

            migrationBuilder.DropColumn(
                name: "Level2",
                table: "BudgetCodeLogs");

            migrationBuilder.DropColumn(
                name: "Level1",
                table: "BudgetCodes");

            migrationBuilder.DropColumn(
                name: "Level2",
                table: "BudgetCodes");
        }
    }
}
