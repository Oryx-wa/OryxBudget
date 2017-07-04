using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Budget44 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkProgramStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BudgetId = table.Column<Guid>(nullable: false),
                    BudgetStatus = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false),
                    WorkProgram = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkProgramStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkProgramStatusLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LogInstance = table.Column<int>(nullable: false),
                    BudgetId = table.Column<Guid>(nullable: false),
                    BudgetStatus = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ProgramStatus = table.Column<int>(nullable: false),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false),
                    WorkProgram = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkProgramStatusLog", x => new { x.Id, x.LogInstance });
                });

            migrationBuilder.CreateTable(
                name: "WorkProgramStatusHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ProgramStatus = table.Column<int>(nullable: false),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false),
                    WorkProgramStatusIdId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkProgramStatusHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkProgramStatusHistory_WorkProgramStatus_WorkProgramStatusIdId",
                        column: x => x.WorkProgramStatusIdId,
                        principalTable: "WorkProgramStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkProgramStatus_Id",
                table: "WorkProgramStatus",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkProgramStatusHistory_WorkProgramStatusIdId",
                table: "WorkProgramStatusHistory",
                column: "WorkProgramStatusIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkProgramStatusHistory");

            migrationBuilder.DropTable(
                name: "WorkProgramStatusLog");

            migrationBuilder.DropTable(
                name: "WorkProgramStatus");
        }
    }
}
