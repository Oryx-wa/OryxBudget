using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Budget16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AmountLC",
                table: "ActualLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountLCInUSD",
                table: "ActualLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountUSD",
                table: "ActualLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodEnd",
                table: "ActualLogs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodStart",
                table: "ActualLogs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "AmountLC",
                table: "Actuals",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountLCInUSD",
                table: "Actuals",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountUSD",
                table: "Actuals",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodEnd",
                table: "Actuals",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodStart",
                table: "Actuals",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountLC",
                table: "ActualLogs");

            migrationBuilder.DropColumn(
                name: "AmountLCInUSD",
                table: "ActualLogs");

            migrationBuilder.DropColumn(
                name: "AmountUSD",
                table: "ActualLogs");

            migrationBuilder.DropColumn(
                name: "PeriodEnd",
                table: "ActualLogs");

            migrationBuilder.DropColumn(
                name: "PeriodStart",
                table: "ActualLogs");

            migrationBuilder.DropColumn(
                name: "AmountLC",
                table: "Actuals");

            migrationBuilder.DropColumn(
                name: "AmountLCInUSD",
                table: "Actuals");

            migrationBuilder.DropColumn(
                name: "AmountUSD",
                table: "Actuals");

            migrationBuilder.DropColumn(
                name: "PeriodEnd",
                table: "Actuals");

            migrationBuilder.DropColumn(
                name: "PeriodStart",
                table: "Actuals");
        }
    }
}
