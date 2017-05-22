using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Budget26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    ItemStatus = table.Column<int>(nullable: false),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusHistoryLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LogInstance = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ItemStatus = table.Column<int>(nullable: false),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusHistoryLog", x => new { x.Id, x.LogInstance });
                });

            migrationBuilder.CreateIndex(
                name: "IX_StatusHistory_Id",
                table: "StatusHistory",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatusHistory");

            migrationBuilder.DropTable(
                name: "StatusHistoryLog");
        }
    }
}
