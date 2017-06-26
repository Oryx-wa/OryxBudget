using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Budget30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineComment_Budgets_BudgetId1",
                table: "LineComment");

            migrationBuilder.DropIndex(
                name: "IX_LineComment_BudgetId1",
                table: "LineComment");

            migrationBuilder.DropColumn(
                name: "BudgetId1",
                table: "LineComment");

            migrationBuilder.RenameColumn(
                name: "BudgetId",
                table: "LineCommentLog",
                newName: "UserType");

            migrationBuilder.RenameColumn(
                name: "BudgetId",
                table: "LineComment",
                newName: "UserType");

            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatus",
                table: "BudgetLineLogs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "LineStatus",
                table: "BudgetLines",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatus",
                table: "BudgetLines",
                nullable: false,
                defaultValueSql: "0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                table: "BudgetLines");

            migrationBuilder.RenameColumn(
                name: "UserType",
                table: "LineCommentLog",
                newName: "BudgetId");

            migrationBuilder.RenameColumn(
                name: "UserType",
                table: "LineComment",
                newName: "BudgetId");

            migrationBuilder.AddColumn<Guid>(
                name: "BudgetId1",
                table: "LineComment",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LineStatus",
                table: "BudgetLines",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "1");

            migrationBuilder.CreateIndex(
                name: "IX_LineComment_BudgetId1",
                table: "LineComment",
                column: "BudgetId1");

            migrationBuilder.AddForeignKey(
                name: "FK_LineComment_Budgets_BudgetId1",
                table: "LineComment",
                column: "BudgetId1",
                principalTable: "Budgets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
