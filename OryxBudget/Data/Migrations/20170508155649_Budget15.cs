using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Budget15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BudgetId",
                table: "ActualLogs",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BudgetId",
                table: "Actuals",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Actuals_BudgetId",
                table: "Actuals",
                column: "BudgetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actuals_Budgets_BudgetId",
                table: "Actuals",
                column: "BudgetId",
                principalTable: "Budgets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actuals_Budgets_BudgetId",
                table: "Actuals");

            migrationBuilder.DropIndex(
                name: "IX_Actuals_BudgetId",
                table: "Actuals");

            migrationBuilder.DropColumn(
                name: "BudgetId",
                table: "ActualLogs");

            migrationBuilder.DropColumn(
                name: "BudgetId",
                table: "Actuals");
        }
    }
}
