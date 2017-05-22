using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Budget24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualAmount",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "ActualAmount",
                table: "BudgetLines");

            migrationBuilder.RenameColumn(
                name: "TotalAmountUSD",
                table: "BudgetLogs",
                newName: "OpBudgetUSD");

            migrationBuilder.RenameColumn(
                name: "TotalAmountLC",
                table: "BudgetLogs",
                newName: "OpBudgetLC");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "BudgetLogs",
                newName: "OpBudgetFC");

            migrationBuilder.RenameColumn(
                name: "ActualBudgetAmount",
                table: "BudgetLogs",
                newName: "OpActualUSD");

            migrationBuilder.RenameColumn(
                name: "ActualAmountUSD",
                table: "BudgetLogs",
                newName: "OpActualLC");

            migrationBuilder.RenameColumn(
                name: "ActualAmountLC",
                table: "BudgetLogs",
                newName: "OpActualFC");

            migrationBuilder.RenameColumn(
                name: "BudgetAmount",
                table: "BudgetLineLogs",
                newName: "OpBudgetUSD");

            migrationBuilder.RenameColumn(
                name: "AmountUSD",
                table: "BudgetLineLogs",
                newName: "OpBudgetLCInUSD");

            migrationBuilder.RenameColumn(
                name: "AmountLCInUSD",
                table: "BudgetLineLogs",
                newName: "OpBudgetLC");

            migrationBuilder.RenameColumn(
                name: "AmountLC",
                table: "BudgetLineLogs",
                newName: "OpBudgetFC");

            migrationBuilder.RenameColumn(
                name: "BudgetAmount",
                table: "BudgetLines",
                newName: "OpBudgetUSD");

            migrationBuilder.RenameColumn(
                name: "AmountUSD",
                table: "BudgetLines",
                newName: "OpBudgetLCInUSD");

            migrationBuilder.RenameColumn(
                name: "AmountLCInUSD",
                table: "BudgetLines",
                newName: "OpBudgetLC");

            migrationBuilder.RenameColumn(
                name: "AmountLC",
                table: "BudgetLines",
                newName: "OpBudgetFC");

            migrationBuilder.RenameColumn(
                name: "TotalBudgetAmount",
                table: "Budgets",
                newName: "OpBudgetUSD");

            migrationBuilder.RenameColumn(
                name: "TotalAmountUSD",
                table: "Budgets",
                newName: "OpBudgetLC");

            migrationBuilder.RenameColumn(
                name: "TotalAmountLC",
                table: "Budgets",
                newName: "OpBudgetFC");

            migrationBuilder.RenameColumn(
                name: "ActualAmountUSD",
                table: "Budgets",
                newName: "OpActualUSD");

            migrationBuilder.RenameColumn(
                name: "ActualAmountLC",
                table: "Budgets",
                newName: "OpActualLC");

            migrationBuilder.RenameColumn(
                name: "ActualAmount",
                table: "Budgets",
                newName: "OpActualFC");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Actuals",
                newName: "OpActualUSD");

            migrationBuilder.RenameColumn(
                name: "AmountUSD",
                table: "Actuals",
                newName: "OpActualLCInUSD");

            migrationBuilder.RenameColumn(
                name: "AmountLCInUSD",
                table: "Actuals",
                newName: "OpActualLC");

            migrationBuilder.RenameColumn(
                name: "AmountLC",
                table: "Actuals",
                newName: "OpActualFC");

            migrationBuilder.AddColumn<int>(
                name: "CommentType",
                table: "LineCommentLog",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "BudgetId1",
                table: "LineComment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommentType",
                table: "LineComment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActualStatus",
                table: "BudgetLogs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BudgetStatus",
                table: "BudgetLogs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalActualFC",
                table: "BudgetLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalActualLC",
                table: "BudgetLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalActualUSD",
                table: "BudgetLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalBudgetFC",
                table: "BudgetLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalBudgetLC",
                table: "BudgetLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalBudgetUSD",
                table: "BudgetLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComActualFC",
                table: "BudgetLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComActualLC",
                table: "BudgetLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComActualUSD",
                table: "BudgetLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComBudgetFC",
                table: "BudgetLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComBudgetLC",
                table: "BudgetLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComBudgetUSD",
                table: "BudgetLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComActualFC",
                table: "BudgetLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComActualLC",
                table: "BudgetLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComActualUSD",
                table: "BudgetLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComBudgetFC",
                table: "BudgetLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComBudgetLC",
                table: "BudgetLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComBudgetUSD",
                table: "BudgetLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TecComActualFC",
                table: "BudgetLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TecComActualLC",
                table: "BudgetLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TecComActualUSD",
                table: "BudgetLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TecComBudgetFC",
                table: "BudgetLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TecComBudgetLC",
                table: "BudgetLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TecComBudgetUSD",
                table: "BudgetLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalBudgetFC",
                table: "BudgetLineLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalBudgetLC",
                table: "BudgetLineLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalBudgetUSD",
                table: "BudgetLineLogs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LineStatus",
                table: "BudgetLineLogs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComBudgetFC",
                table: "BudgetLineLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComBudgetLC",
                table: "BudgetLineLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComBudgetUSD",
                table: "BudgetLineLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComBudgetFC",
                table: "BudgetLineLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComBudgetLC",
                table: "BudgetLineLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComBudgetUSD",
                table: "BudgetLineLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TecComBudgetFC",
                table: "BudgetLineLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TecComBudgetLC",
                table: "BudgetLineLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TecComBudgetUSD",
                table: "BudgetLineLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalBudgetFC",
                table: "BudgetLines",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalBudgetLC",
                table: "BudgetLines",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalBudgetUSD",
                table: "BudgetLines",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LineStatus",
                table: "BudgetLines",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComBudgetFC",
                table: "BudgetLines",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComBudgetLC",
                table: "BudgetLines",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComBudgetUSD",
                table: "BudgetLines",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComBudgetFC",
                table: "BudgetLines",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComBudgetLC",
                table: "BudgetLines",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComBudgetUSD",
                table: "BudgetLines",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TecComBudgetFC",
                table: "BudgetLines",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TecComBudgetLC",
                table: "BudgetLines",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TecComBudgetUSD",
                table: "BudgetLines",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActualStatus",
                table: "Budgets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BudgetStatus",
                table: "Budgets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalActualFC",
                table: "Budgets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalActualLC",
                table: "Budgets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalActualUSD",
                table: "Budgets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalBudgetFC",
                table: "Budgets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalBudgetLC",
                table: "Budgets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalBudgetUSD",
                table: "Budgets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComActualFC",
                table: "Budgets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComActualLC",
                table: "Budgets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComActualUSD",
                table: "Budgets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComBudgetFC",
                table: "Budgets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComBudgetLC",
                table: "Budgets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComBudgetUSD",
                table: "Budgets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComActualFC",
                table: "Budgets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComActualLC",
                table: "Budgets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComActualUSD",
                table: "Budgets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComBudgetFC",
                table: "Budgets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComBudgetLC",
                table: "Budgets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComBudgetUSD",
                table: "Budgets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TecComActualFC",
                table: "Budgets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TecComActualLC",
                table: "Budgets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TecComActualUSD",
                table: "Budgets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TecComBudgetFC",
                table: "Budgets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TecComBudgetLC",
                table: "Budgets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TecComBudgetUSD",
                table: "Budgets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PeriodId",
                table: "ActualLogs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalActualFC",
                table: "Actuals",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalActualLC",
                table: "Actuals",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalActualUSD",
                table: "Actuals",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LineStatus",
                table: "Actuals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComActualFC",
                table: "Actuals",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComActualLC",
                table: "Actuals",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComActualUSD",
                table: "Actuals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PeriodId",
                table: "Actuals",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComActualFC",
                table: "Actuals",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComActualLC",
                table: "Actuals",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComActualUSD",
                table: "Actuals",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TecComActualFC",
                table: "Actuals",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TecComActualLC",
                table: "Actuals",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TecComActualUSD",
                table: "Actuals",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineComment_Budgets_BudgetId1",
                table: "LineComment");

            migrationBuilder.DropIndex(
                name: "IX_LineComment_BudgetId1",
                table: "LineComment");

            migrationBuilder.DropColumn(
                name: "CommentType",
                table: "LineCommentLog");

            migrationBuilder.DropColumn(
                name: "BudgetId1",
                table: "LineComment");

            migrationBuilder.DropColumn(
                name: "CommentType",
                table: "LineComment");

            migrationBuilder.DropColumn(
                name: "ActualStatus",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "BudgetStatus",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "FinalActualFC",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "FinalActualLC",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "FinalActualUSD",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "FinalBudgetFC",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "FinalBudgetLC",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "FinalBudgetUSD",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "MalComActualFC",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "MalComActualLC",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "MalComActualUSD",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "MalComBudgetFC",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "MalComBudgetLC",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "MalComBudgetUSD",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "SubComActualFC",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "SubComActualLC",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "SubComActualUSD",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "SubComBudgetFC",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "SubComBudgetLC",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "SubComBudgetUSD",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "TecComActualFC",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "TecComActualLC",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "TecComActualUSD",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "TecComBudgetFC",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "TecComBudgetLC",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "TecComBudgetUSD",
                table: "BudgetLogs");

            migrationBuilder.DropColumn(
                name: "FinalBudgetFC",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "FinalBudgetLC",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "FinalBudgetUSD",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "LineStatus",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "MalComBudgetFC",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "MalComBudgetLC",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "MalComBudgetUSD",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "SubComBudgetFC",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "SubComBudgetLC",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "SubComBudgetUSD",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "TecComBudgetFC",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "TecComBudgetLC",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "TecComBudgetUSD",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "FinalBudgetFC",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "FinalBudgetLC",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "FinalBudgetUSD",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "LineStatus",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "MalComBudgetFC",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "MalComBudgetLC",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "MalComBudgetUSD",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "SubComBudgetFC",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "SubComBudgetLC",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "SubComBudgetUSD",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "TecComBudgetFC",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "TecComBudgetLC",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "TecComBudgetUSD",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "ActualStatus",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "BudgetStatus",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "FinalActualFC",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "FinalActualLC",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "FinalActualUSD",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "FinalBudgetFC",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "FinalBudgetLC",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "FinalBudgetUSD",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "MalComActualFC",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "MalComActualLC",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "MalComActualUSD",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "MalComBudgetFC",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "MalComBudgetLC",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "MalComBudgetUSD",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "SubComActualFC",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "SubComActualLC",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "SubComActualUSD",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "SubComBudgetFC",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "SubComBudgetLC",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "SubComBudgetUSD",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "TecComActualFC",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "TecComActualLC",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "TecComActualUSD",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "TecComBudgetFC",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "TecComBudgetLC",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "TecComBudgetUSD",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "ActualLogs");

            migrationBuilder.DropColumn(
                name: "FinalActualFC",
                table: "Actuals");

            migrationBuilder.DropColumn(
                name: "FinalActualLC",
                table: "Actuals");

            migrationBuilder.DropColumn(
                name: "FinalActualUSD",
                table: "Actuals");

            migrationBuilder.DropColumn(
                name: "LineStatus",
                table: "Actuals");

            migrationBuilder.DropColumn(
                name: "MalComActualFC",
                table: "Actuals");

            migrationBuilder.DropColumn(
                name: "MalComActualLC",
                table: "Actuals");

            migrationBuilder.DropColumn(
                name: "MalComActualUSD",
                table: "Actuals");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "Actuals");

            migrationBuilder.DropColumn(
                name: "SubComActualFC",
                table: "Actuals");

            migrationBuilder.DropColumn(
                name: "SubComActualLC",
                table: "Actuals");

            migrationBuilder.DropColumn(
                name: "SubComActualUSD",
                table: "Actuals");

            migrationBuilder.DropColumn(
                name: "TecComActualFC",
                table: "Actuals");

            migrationBuilder.DropColumn(
                name: "TecComActualLC",
                table: "Actuals");

            migrationBuilder.DropColumn(
                name: "TecComActualUSD",
                table: "Actuals");

            migrationBuilder.RenameColumn(
                name: "OpBudgetUSD",
                table: "BudgetLogs",
                newName: "TotalAmountUSD");

            migrationBuilder.RenameColumn(
                name: "OpBudgetLC",
                table: "BudgetLogs",
                newName: "TotalAmountLC");

            migrationBuilder.RenameColumn(
                name: "OpBudgetFC",
                table: "BudgetLogs",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "OpActualUSD",
                table: "BudgetLogs",
                newName: "ActualBudgetAmount");

            migrationBuilder.RenameColumn(
                name: "OpActualLC",
                table: "BudgetLogs",
                newName: "ActualAmountUSD");

            migrationBuilder.RenameColumn(
                name: "OpActualFC",
                table: "BudgetLogs",
                newName: "ActualAmountLC");

            migrationBuilder.RenameColumn(
                name: "OpBudgetUSD",
                table: "BudgetLineLogs",
                newName: "BudgetAmount");

            migrationBuilder.RenameColumn(
                name: "OpBudgetLCInUSD",
                table: "BudgetLineLogs",
                newName: "AmountUSD");

            migrationBuilder.RenameColumn(
                name: "OpBudgetLC",
                table: "BudgetLineLogs",
                newName: "AmountLCInUSD");

            migrationBuilder.RenameColumn(
                name: "OpBudgetFC",
                table: "BudgetLineLogs",
                newName: "AmountLC");

            migrationBuilder.RenameColumn(
                name: "OpBudgetUSD",
                table: "BudgetLines",
                newName: "BudgetAmount");

            migrationBuilder.RenameColumn(
                name: "OpBudgetLCInUSD",
                table: "BudgetLines",
                newName: "AmountUSD");

            migrationBuilder.RenameColumn(
                name: "OpBudgetLC",
                table: "BudgetLines",
                newName: "AmountLCInUSD");

            migrationBuilder.RenameColumn(
                name: "OpBudgetFC",
                table: "BudgetLines",
                newName: "AmountLC");

            migrationBuilder.RenameColumn(
                name: "OpBudgetUSD",
                table: "Budgets",
                newName: "TotalBudgetAmount");

            migrationBuilder.RenameColumn(
                name: "OpBudgetLC",
                table: "Budgets",
                newName: "TotalAmountUSD");

            migrationBuilder.RenameColumn(
                name: "OpBudgetFC",
                table: "Budgets",
                newName: "TotalAmountLC");

            migrationBuilder.RenameColumn(
                name: "OpActualUSD",
                table: "Budgets",
                newName: "ActualAmountUSD");

            migrationBuilder.RenameColumn(
                name: "OpActualLC",
                table: "Budgets",
                newName: "ActualAmountLC");

            migrationBuilder.RenameColumn(
                name: "OpActualFC",
                table: "Budgets",
                newName: "ActualAmount");

            migrationBuilder.RenameColumn(
                name: "OpActualUSD",
                table: "Actuals",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "OpActualLCInUSD",
                table: "Actuals",
                newName: "AmountUSD");

            migrationBuilder.RenameColumn(
                name: "OpActualLC",
                table: "Actuals",
                newName: "AmountLCInUSD");

            migrationBuilder.RenameColumn(
                name: "OpActualFC",
                table: "Actuals",
                newName: "AmountLC");

            migrationBuilder.AddColumn<decimal>(
                name: "ActualAmount",
                table: "BudgetLineLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ActualAmount",
                table: "BudgetLines",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
