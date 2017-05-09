using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Budget3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetCodes_Categories_CategoryId1",
                table: "BudgetCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetCodeLogs_Categories_CategoryId1",
                table: "BudgetCodeLogs");

            migrationBuilder.DropIndex(
                name: "IX_BudgetCodeLogs_CategoryId1",
                table: "BudgetCodeLogs");

            migrationBuilder.DropIndex(
                name: "IX_BudgetCodes_CategoryId1",
                table: "BudgetCodes");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "BudgetCodeLogs");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "BudgetCodes");

            migrationBuilder.AlterColumn<string>(
                name: "Postable",
                table: "BudgetCodeLogs",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "BudgetCodeLogs",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Postable",
                table: "BudgetCodes",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "BudgetCodes",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Active",
                table: "BudgetCodes",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Postable",
                table: "BudgetCodeLogs",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "BudgetCodeLogs",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId1",
                table: "BudgetCodeLogs",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Postable",
                table: "BudgetCodes",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "BudgetCodes",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Active",
                table: "BudgetCodes",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId1",
                table: "BudgetCodes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BudgetCodeLogs_CategoryId1",
                table: "BudgetCodeLogs",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetCodes_CategoryId1",
                table: "BudgetCodes",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetCodes_Categories_CategoryId1",
                table: "BudgetCodes",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetCodeLogs_Categories_CategoryId1",
                table: "BudgetCodeLogs",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
