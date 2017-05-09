using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Budget1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Postable",
                table: "BudgetCodeLogs",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Postable",
                table: "BudgetCodes",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Postable",
                table: "BudgetCodeLogs");

            migrationBuilder.DropColumn(
                name: "Postable",
                table: "BudgetCodes");
        }
    }
}
