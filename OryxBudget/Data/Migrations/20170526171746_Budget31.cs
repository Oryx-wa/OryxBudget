using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Budget31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BudgetId",
                table: "LineCommentLog",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BudgetId",
                table: "LineComment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LineComment_BudgetId",
                table: "LineComment",
                column: "BudgetId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineComment_Budgets_BudgetId",
                table: "LineComment",
                column: "BudgetId",
                principalTable: "Budgets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineComment_Budgets_BudgetId",
                table: "LineComment");

            migrationBuilder.DropIndex(
                name: "IX_LineComment_BudgetId",
                table: "LineComment");

            migrationBuilder.DropColumn(
                name: "BudgetId",
                table: "LineCommentLog");

            migrationBuilder.DropColumn(
                name: "BudgetId",
                table: "LineComment");
        }
    }
}
