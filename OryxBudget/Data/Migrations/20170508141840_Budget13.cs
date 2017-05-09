using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Budget13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AmountLCInUSD",
                table: "BudgetLineLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountLCInUSD",
                table: "BudgetLines",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountLCInUSD",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "AmountLCInUSD",
                table: "BudgetLines");
        }
    }
}
