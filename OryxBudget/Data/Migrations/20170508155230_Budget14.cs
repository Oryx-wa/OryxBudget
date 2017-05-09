using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Budget14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BudgetId",
                table: "ActualLogs");

            migrationBuilder.DropColumn(
                name: "BudgetId",
                table: "Actuals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BudgetId",
                table: "ActualLogs",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BudgetId",
                table: "Actuals",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
