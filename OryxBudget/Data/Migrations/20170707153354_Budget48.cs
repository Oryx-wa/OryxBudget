using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Budget48 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BudgetCode = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    IsRead = table.Column<bool>(nullable: false),
                    LineCommentId = table.Column<Guid>(nullable: false),
                    OperatorId = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UrlData = table.Column<string>(maxLength: 100, nullable: true),
                    User = table.Column<Guid>(nullable: true),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false),
                    Username = table.Column<string>(nullable: true),
                    WorkProgramId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BudgetCode = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    IsRead = table.Column<bool>(nullable: false),
                    LineCommentId = table.Column<Guid>(nullable: false),
                    LogInstance = table.Column<int>(nullable: false),
                    OperatorId = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UrlData = table.Column<string>(maxLength: 100, nullable: true),
                    User = table.Column<Guid>(nullable: true),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false),
                    Username = table.Column<string>(maxLength: 100, nullable: false),
                    WorkProgramId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "NotificationLogs");
        }
    }
}
