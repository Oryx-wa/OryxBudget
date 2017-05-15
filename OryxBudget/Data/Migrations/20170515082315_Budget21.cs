using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Budget21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineComment_BudgetLines_BudgetLineId",
                table: "LineComment");

            migrationBuilder.DropIndex(
                name: "IX_LineComment_BudgetLineId",
                table: "LineComment");

            migrationBuilder.RenameColumn(
                name: "BudgetLineId",
                table: "LineCommentLog",
                newName: "BudgetId");

            migrationBuilder.RenameColumn(
                name: "BudgetLineId",
                table: "LineComment",
                newName: "BudgetId");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "LineCommentLog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "LineComment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "LineCommentLog");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "LineComment");

            migrationBuilder.RenameColumn(
                name: "BudgetId",
                table: "LineCommentLog",
                newName: "BudgetLineId");

            migrationBuilder.RenameColumn(
                name: "BudgetId",
                table: "LineComment",
                newName: "BudgetLineId");

            migrationBuilder.CreateIndex(
                name: "IX_LineComment_BudgetLineId",
                table: "LineComment",
                column: "BudgetLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineComment_BudgetLines_BudgetLineId",
                table: "LineComment",
                column: "BudgetLineId",
                principalTable: "BudgetLines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
