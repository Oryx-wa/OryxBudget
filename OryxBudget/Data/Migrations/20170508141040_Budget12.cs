using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Budget12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmountLC",
                table: "BudgetLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmountUSD",
                table: "BudgetLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountLC",
                table: "BudgetLineLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountUSD",
                table: "BudgetLineLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountLC",
                table: "BudgetLines",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountUSD",
                table: "BudgetLines",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmountLC",
                table: "Budgets",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmountUSD",
                table: "Budgets",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmountLC",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "TotalAmountUSD",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "AmountLC",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "AmountUSD",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "AmountLC",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "AmountUSD",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "TotalAmountLC",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "TotalAmountUSD",
                table: "Budgets");
        }
    }
}
