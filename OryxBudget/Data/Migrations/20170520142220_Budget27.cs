using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Budget27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OpBudgetUSD",
                table: "BudgetLineLogs",
                newName: "OpBudgetUSD1");

            migrationBuilder.RenameColumn(
                name: "OpBudgetUSD",
                table: "BudgetLines",
                newName: "OpBudgetUSD1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OpBudgetUSD1",
                table: "BudgetLineLogs",
                newName: "OpBudgetUSD");

            migrationBuilder.RenameColumn(
                name: "OpBudgetUSD1",
                table: "BudgetLines",
                newName: "OpBudgetUSD");
        }
    }
}
