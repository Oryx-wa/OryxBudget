using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Budget42 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "ActualLogs",
                newName: "TecComActualUSD");

            migrationBuilder.RenameColumn(
                name: "AmountUSD",
                table: "ActualLogs",
                newName: "TecComActualLC");

            migrationBuilder.RenameColumn(
                name: "AmountLCInUSD",
                table: "ActualLogs",
                newName: "TecComActualFC");

            migrationBuilder.RenameColumn(
                name: "AmountLC",
                table: "ActualLogs",
                newName: "SubComActualUSD");

            migrationBuilder.AddColumn<decimal>(
                name: "FinalActualFC",
                table: "BudgetLineLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalActualLC",
                table: "BudgetLineLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalActualUSD",
                table: "BudgetLineLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComActualFC",
                table: "BudgetLineLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComActualLC",
                table: "BudgetLineLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComActualUSD",
                table: "BudgetLineLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OpActualFC",
                table: "BudgetLineLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OpActualLC",
                table: "BudgetLineLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OpActualLCInUSD",
                table: "BudgetLineLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OpActualUSD",
                table: "BudgetLineLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComActualFC",
                table: "BudgetLineLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComActualLC",
                table: "BudgetLineLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComActualUSD",
                table: "BudgetLineLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TecComActualFC",
                table: "BudgetLineLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TecComActualLC",
                table: "BudgetLineLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TecComActualUSD",
                table: "BudgetLineLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalActualFC",
                table: "BudgetLines",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalActualLC",
                table: "BudgetLines",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalActualUSD",
                table: "BudgetLines",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComActualFC",
                table: "BudgetLines",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComActualLC",
                table: "BudgetLines",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComActualUSD",
                table: "BudgetLines",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OpActualFC",
                table: "BudgetLines",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OpActualLC",
                table: "BudgetLines",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OpActualLCInUSD",
                table: "BudgetLines",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OpActualUSD",
                table: "BudgetLines",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComActualFC",
                table: "BudgetLines",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComActualLC",
                table: "BudgetLines",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComActualUSD",
                table: "BudgetLines",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TecComActualFC",
                table: "BudgetLines",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TecComActualLC",
                table: "BudgetLines",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TecComActualUSD",
                table: "BudgetLines",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "BudgetLineId",
                table: "ActualLogs",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "FinalActualFC",
                table: "ActualLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalActualLC",
                table: "ActualLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalActualUSD",
                table: "ActualLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "LineStatus",
                table: "ActualLogs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComActualFC",
                table: "ActualLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComActualLC",
                table: "ActualLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MalComActualUSD",
                table: "ActualLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OpActualFC",
                table: "ActualLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OpActualLC",
                table: "ActualLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OpActualLCInUSD",
                table: "ActualLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OpActualUSD",
                table: "ActualLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComActualFC",
                table: "ActualLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SubComActualLC",
                table: "ActualLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "BudgetLineId",
                table: "Actuals",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalActualFC",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "FinalActualLC",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "FinalActualUSD",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "MalComActualFC",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "MalComActualLC",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "MalComActualUSD",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "OpActualFC",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "OpActualLC",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "OpActualLCInUSD",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "OpActualUSD",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "SubComActualFC",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "SubComActualLC",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "SubComActualUSD",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "TecComActualFC",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "TecComActualLC",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "TecComActualUSD",
                table: "BudgetLineLogs");

            migrationBuilder.DropColumn(
                name: "FinalActualFC",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "FinalActualLC",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "FinalActualUSD",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "MalComActualFC",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "MalComActualLC",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "MalComActualUSD",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "OpActualFC",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "OpActualLC",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "OpActualLCInUSD",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "OpActualUSD",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "SubComActualFC",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "SubComActualLC",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "SubComActualUSD",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "TecComActualFC",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "TecComActualLC",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "TecComActualUSD",
                table: "BudgetLines");

            migrationBuilder.DropColumn(
                name: "BudgetLineId",
                table: "ActualLogs");

            migrationBuilder.DropColumn(
                name: "FinalActualFC",
                table: "ActualLogs");

            migrationBuilder.DropColumn(
                name: "FinalActualLC",
                table: "ActualLogs");

            migrationBuilder.DropColumn(
                name: "FinalActualUSD",
                table: "ActualLogs");

            migrationBuilder.DropColumn(
                name: "LineStatus",
                table: "ActualLogs");

            migrationBuilder.DropColumn(
                name: "MalComActualFC",
                table: "ActualLogs");

            migrationBuilder.DropColumn(
                name: "MalComActualLC",
                table: "ActualLogs");

            migrationBuilder.DropColumn(
                name: "MalComActualUSD",
                table: "ActualLogs");

            migrationBuilder.DropColumn(
                name: "OpActualFC",
                table: "ActualLogs");

            migrationBuilder.DropColumn(
                name: "OpActualLC",
                table: "ActualLogs");

            migrationBuilder.DropColumn(
                name: "OpActualLCInUSD",
                table: "ActualLogs");

            migrationBuilder.DropColumn(
                name: "OpActualUSD",
                table: "ActualLogs");

            migrationBuilder.DropColumn(
                name: "SubComActualFC",
                table: "ActualLogs");

            migrationBuilder.DropColumn(
                name: "SubComActualLC",
                table: "ActualLogs");

            migrationBuilder.DropColumn(
                name: "BudgetLineId",
                table: "Actuals");

            migrationBuilder.RenameColumn(
                name: "TecComActualUSD",
                table: "ActualLogs",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "TecComActualLC",
                table: "ActualLogs",
                newName: "AmountUSD");

            migrationBuilder.RenameColumn(
                name: "TecComActualFC",
                table: "ActualLogs",
                newName: "AmountLCInUSD");

            migrationBuilder.RenameColumn(
                name: "SubComActualUSD",
                table: "ActualLogs",
                newName: "AmountLC");
        }
    }
}
