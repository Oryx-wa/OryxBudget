using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Budget7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Budgets_Categories_BudgetCategoryId",
                table: "Budgets");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetLines_Budgets_BudgetId1",
                table: "BudgetLines");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetLines_Categories_BudgetLineCategoryId",
                table: "BudgetLines");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetLineLogs_Budgets_BudgetId1",
                table: "BudgetLineLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetLineLogs_Categories_CategoryId1",
                table: "BudgetLineLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_BudgetLogs_Categories_BudgetCategoryId",
                table: "BudgetLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_LineComment_BudgetLines_BudgetLineId1",
                table: "LineComment");

            migrationBuilder.DropForeignKey(
                name: "FK_LineComment_BudgetLineLogs_BudgetLineLogId_BudgetLineLogLogInstance",
                table: "LineComment");

            migrationBuilder.DropForeignKey(
                name: "FK_LineCommentLog_BudgetLines_BudgetLineId1",
                table: "LineCommentLog");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactPersons_Operators_OperatorId1",
                table: "ContactPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactPersonLogs_Operators_OperatorId1",
                table: "ContactPersonLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Operators_OperatorTypes_OperatorTypeId1",
                table: "Operators");

            migrationBuilder.DropForeignKey(
                name: "FK_Operators_OperatorTypeLogs_OperatorTypeLogId_OperatorTypeLogLogInstance",
                table: "Operators");

            migrationBuilder.DropForeignKey(
                name: "FK_OperatorLogs_ContactPersons_ContactPersonId1",
                table: "OperatorLogs");

            migrationBuilder.DropIndex(
                name: "IX_OperatorLogs_ContactPersonId1",
                table: "OperatorLogs");

            migrationBuilder.DropIndex(
                name: "IX_Operators_OperatorTypeId1",
                table: "Operators");

            migrationBuilder.DropIndex(
                name: "IX_Operators_OperatorTypeLogId_OperatorTypeLogLogInstance",
                table: "Operators");

            migrationBuilder.DropIndex(
                name: "IX_ContactPersonLogs_OperatorId1",
                table: "ContactPersonLogs");

            migrationBuilder.DropIndex(
                name: "IX_ContactPersons_OperatorId1",
                table: "ContactPersons");

            migrationBuilder.DropIndex(
                name: "IX_LineCommentLog_BudgetLineId1",
                table: "LineCommentLog");

            migrationBuilder.DropIndex(
                name: "IX_LineComment_BudgetLineId1",
                table: "LineComment");

            migrationBuilder.DropIndex(
                name: "IX_LineComment_BudgetLineLogId_BudgetLineLogLogInstance",
                table: "LineComment");

            migrationBuilder.DropIndex(
                name: "IX_BudgetLogs_BudgetCategoryId",
                table: "BudgetLogs");

            migrationBuilder.DropIndex(
                name: "IX_BudgetLineLogs_BudgetId1",
                table: "BudgetLineLogs");

            migrationBuilder.DropIndex(
                name: "IX_BudgetLineLogs_CategoryId1",
                table: "BudgetLineLogs");

            migrationBuilder.DropIndex(
                name: "IX_BudgetLines_BudgetId1",
                table: "BudgetLines");

            migrationBuilder.DropIndex(
                name: "IX_BudgetLines_BudgetLineCategoryId",
                table: "BudgetLines");

            migrationBuilder.DropIndex(
                name: "IX_Budgets_BudgetCategoryId",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "ContactPersonId",
                table: "OperatorLogs");

            migrationBuilder.DropColumn(
                name: "ContactPersonId1",
                table: "OperatorLogs");

            migrationBuilder.DropColumn(
                name: "ContactPersonId",
                table: "Operators");

            migrationBuilder.DropColumn(
                name: "OperatorTypeId1",
                table: "Operators");

            migrationBuilder.DropColumn(
                name: "OperatorTypeLogId",
                table: "Operators");

            migrationBuilder.DropColumn(
                name: "OperatorTypeLogLogInstance",
                table: "Operators");

            migrationBuilder.DropColumn(
                name: "OperatorId1",
                table: "ContactPersonLogs");

            migrationBuilder.DropColumn(
                name: "OperatorId1",
                table: "ContactPersons");

            migrationBuilder.DropColumn(
                name: "BudgetLineId1",
                table: "LineCommentLog");

            migrationBuilder.DropColumn(
                name: "BudgetLineId1",
                table: "LineComment");

            migrationBuilder.DropColumn(
                name: "BudgetLineLogId",
                table: "LineComment");

            migrationBuilder.DropColumn(
                name: "BudgetLineLogLogInstance",
                table: "LineComment");

            migrationBuilder.DropColumn(
                name: "BudgetCategoryId",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "BudgetId1",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "BudgetId1",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "BudgetLineCategoryId",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "BudgetCategoryId",
                table: "Budgets");

            migrationBuilder.AlterColumn<Guid>(
                name: "OperatorId",
                table: "ContactPersons",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<Guid>(
                name: "BudgetLineId",
                table: "LineCommentLog",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<Guid>(
                name: "BudgetLineId",
                table: "LineComment",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "BudgetLogs",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "BudgetLineLogs",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<Guid>(
                name: "BudgetId",
                table: "BudgetLineLogs",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "BudgetLines",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<Guid>(
                name: "BudgetId",
                table: "BudgetLines",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "Budgets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PeriodId",
                table: "ActualLogs",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PeriodId",
                table: "Actuals",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPersons_OperatorId",
                table: "ContactPersons",
                column: "OperatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPersons_Operators_OperatorId",
                table: "ContactPersons",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactPersons_Operators_OperatorId",
                table: "ContactPersons");

            migrationBuilder.DropIndex(
                name: "IX_ContactPersons_OperatorId",
                table: "ContactPersons");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "ActualLogs");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "Actuals");

            migrationBuilder.AddColumn<string>(
                name: "ContactPersonId",
                table: "OperatorLogs",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ContactPersonId1",
                table: "OperatorLogs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPersonId",
                table: "Operators",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OperatorTypeId1",
                table: "Operators",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OperatorTypeLogId",
                table: "Operators",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OperatorTypeLogLogInstance",
                table: "Operators",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OperatorId1",
                table: "ContactPersonLogs",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OperatorId",
                table: "ContactPersons",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(Guid),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<Guid>(
                name: "OperatorId1",
                table: "ContactPersons",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BudgetLineId",
                table: "LineCommentLog",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "BudgetLineId1",
                table: "LineCommentLog",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BudgetLineId",
                table: "LineComment",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "BudgetLineId1",
                table: "LineComment",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BudgetLineLogId",
                table: "LineComment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BudgetLineLogLogInstance",
                table: "LineComment",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BudgetCategoryId",
                table: "BudgetLogs",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "BudgetLineLogs",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BudgetId",
                table: "BudgetLineLogs",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "BudgetId1",
                table: "BudgetLineLogs",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId1",
                table: "BudgetLineLogs",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "BudgetLines",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BudgetId",
                table: "BudgetLines",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "BudgetId1",
                table: "BudgetLines",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BudgetLineCategoryId",
                table: "BudgetLines",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BudgetCategoryId",
                table: "Budgets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperatorLogs_ContactPersonId1",
                table: "OperatorLogs",
                column: "ContactPersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_Operators_OperatorTypeId1",
                table: "Operators",
                column: "OperatorTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Operators_OperatorTypeLogId_OperatorTypeLogLogInstance",
                table: "Operators",
                columns: new[] { "OperatorTypeLogId", "OperatorTypeLogLogInstance" });

            migrationBuilder.CreateIndex(
                name: "IX_ContactPersonLogs_OperatorId1",
                table: "ContactPersonLogs",
                column: "OperatorId1");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPersons_OperatorId1",
                table: "ContactPersons",
                column: "OperatorId1");

            migrationBuilder.CreateIndex(
                name: "IX_LineCommentLog_BudgetLineId1",
                table: "LineCommentLog",
                column: "BudgetLineId1");

            migrationBuilder.CreateIndex(
                name: "IX_LineComment_BudgetLineId1",
                table: "LineComment",
                column: "BudgetLineId1");

            migrationBuilder.CreateIndex(
                name: "IX_LineComment_BudgetLineLogId_BudgetLineLogLogInstance",
                table: "LineComment",
                columns: new[] { "BudgetLineLogId", "BudgetLineLogLogInstance" });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLogs_BudgetCategoryId",
                table: "BudgetLogs",
                column: "BudgetCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLineLogs_BudgetId1",
                table: "BudgetLineLogs",
                column: "BudgetId1");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLineLogs_CategoryId1",
                table: "BudgetLineLogs",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLines_BudgetId1",
                table: "BudgetLines",
                column: "BudgetId1");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLines_BudgetLineCategoryId",
                table: "BudgetLines",
                column: "BudgetLineCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_BudgetCategoryId",
                table: "Budgets",
                column: "BudgetCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Budgets_Categories_BudgetCategoryId",
                table: "Budgets",
                column: "BudgetCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetLines_Budgets_BudgetId1",
                table: "BudgetLines",
                column: "BudgetId1",
                principalTable: "Budgets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetLines_Categories_BudgetLineCategoryId",
                table: "BudgetLines",
                column: "BudgetLineCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetLineLogs_Budgets_BudgetId1",
                table: "BudgetLineLogs",
                column: "BudgetId1",
                principalTable: "Budgets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetLineLogs_Categories_CategoryId1",
                table: "BudgetLineLogs",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetLogs_Categories_BudgetCategoryId",
                table: "BudgetLogs",
                column: "BudgetCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LineComment_BudgetLines_BudgetLineId1",
                table: "LineComment",
                column: "BudgetLineId1",
                principalTable: "BudgetLines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LineComment_BudgetLineLogs_BudgetLineLogId_BudgetLineLogLogInstance",
                table: "LineComment",
                columns: new[] { "BudgetLineLogId", "BudgetLineLogLogInstance" },
                principalTable: "BudgetLineLogs",
                principalColumns: new[] { "Id", "LogInstance" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LineCommentLog_BudgetLines_BudgetLineId1",
                table: "LineCommentLog",
                column: "BudgetLineId1",
                principalTable: "BudgetLines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPersons_Operators_OperatorId1",
                table: "ContactPersons",
                column: "OperatorId1",
                principalTable: "Operators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPersonLogs_Operators_OperatorId1",
                table: "ContactPersonLogs",
                column: "OperatorId1",
                principalTable: "Operators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Operators_OperatorTypes_OperatorTypeId1",
                table: "Operators",
                column: "OperatorTypeId1",
                principalTable: "OperatorTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Operators_OperatorTypeLogs_OperatorTypeLogId_OperatorTypeLogLogInstance",
                table: "Operators",
                columns: new[] { "OperatorTypeLogId", "OperatorTypeLogLogInstance" },
                principalTable: "OperatorTypeLogs",
                principalColumns: new[] { "Id", "LogInstance" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OperatorLogs_ContactPersons_ContactPersonId1",
                table: "OperatorLogs",
                column: "ContactPersonId1",
                principalTable: "ContactPersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
