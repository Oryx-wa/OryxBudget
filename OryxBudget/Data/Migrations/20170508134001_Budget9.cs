using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Budget9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BudgetId",
                table: "BudgetLines",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLines_BudgetId",
                table: "BudgetLines",
                column: "BudgetId");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetLines_Budgets_BudgetId",
                table: "BudgetLines",
                column: "BudgetId",
                principalTable: "Budgets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetLines_Budgets_BudgetId",
                table: "BudgetLines");

            migrationBuilder.DropIndex(
                name: "IX_BudgetLines_BudgetId",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "BudgetId",
                table: "BudgetLines");
        }
    }
}
