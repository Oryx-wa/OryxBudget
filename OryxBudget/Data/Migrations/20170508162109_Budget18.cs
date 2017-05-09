using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Budget18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "ActualLogs");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "Actuals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
