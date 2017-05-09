using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Budget17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalBudgetAmount",
                table: "BudgetLogs",
                newName: "TotalAmount");

            migrationBuilder.AddColumn<decimal>(
                name: "ActualAmountLC",
                table: "BudgetLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ActualAmountUSD",
                table: "BudgetLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ActualBudgetAmount",
                table: "BudgetLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ActualAmount",
                table: "Budgets",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ActualAmountLC",
                table: "Budgets",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ActualAmountUSD",
                table: "Budgets",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualAmountLC",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "ActualAmountUSD",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "ActualBudgetAmount",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "ActualAmount",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "ActualAmountLC",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "ActualAmountUSD",
                table: "Budgets");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "BudgetLogs",
                newName: "TotalBudgetAmount");
        }
    }
}
