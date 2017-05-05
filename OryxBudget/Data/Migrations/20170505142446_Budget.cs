using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Budget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actuals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BudgetId = table.Column<string>(maxLength: 50, nullable: false),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    Remarks = table.Column<string>(maxLength: 150, nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    TotalAmount = table.Column<decimal>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actuals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActualLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LogInstance = table.Column<int>(nullable: false),
                    BudgetId = table.Column<string>(maxLength: 50, nullable: false),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    Remarks = table.Column<string>(maxLength: 150, nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    TotalAmount = table.Column<decimal>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualLogs", x => new { x.Id, x.LogInstance });
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LogInstance = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryLogs", x => new { x.Id, x.LogInstance });
                    table.UniqueConstraint("AK_CategoryLogs_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Periods",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeriodLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LogInstance = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodLogs", x => new { x.Id, x.LogInstance });
                });

            migrationBuilder.CreateTable(
                name: "OperatorTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(maxLength: 50, nullable: false, defaultValueSql: "getDate()"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperatorTypeLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LogInstance = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorTypeLogs", x => new { x.Id, x.LogInstance });
                });

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AdditionalStatement = table.Column<string>(maxLength: 300, nullable: true),
                    BudgetCategoryId = table.Column<Guid>(nullable: true),
                    BudgetLineCategoryId = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    OperatorId = table.Column<string>(maxLength: 50, nullable: false),
                    PeriodId = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    TotalBudgetAmount = table.Column<decimal>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Budgets_Categories_BudgetCategoryId",
                        column: x => x.BudgetCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BudgetCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<string>(maxLength: 50, nullable: false),
                    CategoryId1 = table.Column<Guid>(nullable: true),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    FatherNum = table.Column<string>(maxLength: 50, nullable: false),
                    Level = table.Column<string>(maxLength: 100, nullable: false),
                    SecondDescription = table.Column<string>(maxLength: 150, nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetCodes_Categories_CategoryId1",
                        column: x => x.CategoryId1,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BudgetCodeLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LogInstance = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<string>(maxLength: 50, nullable: false),
                    CategoryId1 = table.Column<Guid>(nullable: true),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    FatherNum = table.Column<string>(maxLength: 50, nullable: false),
                    Level = table.Column<string>(maxLength: 100, nullable: false),
                    SecondDescription = table.Column<string>(maxLength: 150, nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetCodeLogs", x => new { x.Id, x.LogInstance });
                    table.UniqueConstraint("AK_BudgetCodeLogs_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetCodeLogs_Categories_CategoryId1",
                        column: x => x.CategoryId1,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BudgetLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LogInstance = table.Column<int>(nullable: false),
                    AdditionalStatement = table.Column<string>(maxLength: 300, nullable: true),
                    BudgetCategoryId = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    OperatorId = table.Column<string>(maxLength: 50, nullable: false),
                    PeriodId = table.Column<string>(nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    TotalBudgetAmount = table.Column<decimal>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetLogs", x => new { x.Id, x.LogInstance });
                    table.ForeignKey(
                        name: "FK_BudgetLogs_Categories_BudgetCategoryId",
                        column: x => x.BudgetCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Operators",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    ContactPersonId = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(maxLength: 50, nullable: false, defaultValueSql: "getDate()"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    OperatorTypeId = table.Column<string>(maxLength: 50, nullable: true),
                    OperatorTypeId1 = table.Column<Guid>(nullable: true),
                    OperatorTypeLogId = table.Column<Guid>(nullable: true),
                    OperatorTypeLogLogInstance = table.Column<int>(nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operators_OperatorTypes_OperatorTypeId1",
                        column: x => x.OperatorTypeId1,
                        principalTable: "OperatorTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operators_OperatorTypeLogs_OperatorTypeLogId_OperatorTypeLogLogInstance",
                        columns: x => new { x.OperatorTypeLogId, x.OperatorTypeLogLogInstance },
                        principalTable: "OperatorTypeLogs",
                        principalColumns: new[] { "Id", "LogInstance" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BudgetLineLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LogInstance = table.Column<int>(nullable: false),
                    ActualAmount = table.Column<decimal>(nullable: false),
                    BudgetAmount = table.Column<decimal>(nullable: false),
                    BudgetId = table.Column<string>(maxLength: 100, nullable: false),
                    BudgetId1 = table.Column<Guid>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    CategoryId1 = table.Column<Guid>(nullable: true),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    RowNumber = table.Column<int>(nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetLineLogs", x => new { x.Id, x.LogInstance });
                    table.ForeignKey(
                        name: "FK_BudgetLineLogs_Budgets_BudgetId1",
                        column: x => x.BudgetId1,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BudgetLineLogs_Categories_CategoryId1",
                        column: x => x.CategoryId1,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BudgetLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ActualAmount = table.Column<decimal>(nullable: false),
                    BudgetAmount = table.Column<decimal>(nullable: false),
                    BudgetId = table.Column<string>(maxLength: 100, nullable: false),
                    BudgetId1 = table.Column<Guid>(nullable: true),
                    BudgetLineCategoryId = table.Column<Guid>(nullable: true),
                    BudgetLogId = table.Column<Guid>(nullable: true),
                    BudgetLogLogInstance = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    RowNumber = table.Column<int>(nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetLines_Budgets_BudgetId1",
                        column: x => x.BudgetId1,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BudgetLines_Categories_BudgetLineCategoryId",
                        column: x => x.BudgetLineCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BudgetLines_BudgetLogs_BudgetLogId_BudgetLogLogInstance",
                        columns: x => new { x.BudgetLogId, x.BudgetLogLogInstance },
                        principalTable: "BudgetLogs",
                        principalColumns: new[] { "Id", "LogInstance" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactPersons",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(maxLength: 50, nullable: false, defaultValueSql: "getDate()"),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    OperatorId = table.Column<string>(maxLength: 50, nullable: false),
                    OperatorId1 = table.Column<Guid>(nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactPersons_Operators_OperatorId1",
                        column: x => x.OperatorId1,
                        principalTable: "Operators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactPersonLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LogInstance = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    OperatorId = table.Column<string>(maxLength: 50, nullable: false),
                    OperatorId1 = table.Column<Guid>(nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPersonLogs", x => new { x.Id, x.LogInstance });
                    table.ForeignKey(
                        name: "FK_ContactPersonLogs_Operators_OperatorId1",
                        column: x => x.OperatorId1,
                        principalTable: "Operators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineComment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BudgetLineId = table.Column<string>(maxLength: 50, nullable: false),
                    BudgetLineId1 = table.Column<Guid>(nullable: true),
                    BudgetLineLogId = table.Column<Guid>(nullable: true),
                    BudgetLineLogLogInstance = table.Column<int>(nullable: true),
                    Comment = table.Column<string>(maxLength: 355, nullable: true),
                    CommentStatus = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineComment_BudgetLines_BudgetLineId1",
                        column: x => x.BudgetLineId1,
                        principalTable: "BudgetLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LineComment_BudgetLineLogs_BudgetLineLogId_BudgetLineLogLogInstance",
                        columns: x => new { x.BudgetLineLogId, x.BudgetLineLogLogInstance },
                        principalTable: "BudgetLineLogs",
                        principalColumns: new[] { "Id", "LogInstance" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineCommentLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LogInstance = table.Column<int>(nullable: false),
                    BudgetLineId = table.Column<string>(maxLength: 50, nullable: false),
                    BudgetLineId1 = table.Column<Guid>(nullable: true),
                    Comment = table.Column<string>(maxLength: 355, nullable: true),
                    CommentStatus = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineCommentLog", x => new { x.Id, x.LogInstance });
                    table.UniqueConstraint("AK_LineCommentLog_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineCommentLog_BudgetLines_BudgetLineId1",
                        column: x => x.BudgetLineId1,
                        principalTable: "BudgetLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OperatorLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LogInstance = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    ContactPersonId = table.Column<string>(maxLength: 50, nullable: true),
                    ContactPersonId1 = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    OperatorTypeId = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorLogs", x => new { x.Id, x.LogInstance });
                    table.ForeignKey(
                        name: "FK_OperatorLogs_ContactPersons_ContactPersonId1",
                        column: x => x.ContactPersonId1,
                        principalTable: "ContactPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actuals_Id",
                table: "Actuals",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_BudgetCategoryId",
                table: "Budgets",
                column: "BudgetCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_Id",
                table: "Budgets",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BudgetCodes_CategoryId1",
                table: "BudgetCodes",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetCodes_Id",
                table: "BudgetCodes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BudgetCodeLogs_CategoryId1",
                table: "BudgetCodeLogs",
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
                name: "IX_BudgetLines_Id",
                table: "BudgetLines",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLines_BudgetLogId_BudgetLogLogInstance",
                table: "BudgetLines",
                columns: new[] { "BudgetLogId", "BudgetLogLogInstance" });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLineLogs_BudgetId1",
                table: "BudgetLineLogs",
                column: "BudgetId1");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLineLogs_CategoryId1",
                table: "BudgetLineLogs",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLogs_BudgetCategoryId",
                table: "BudgetLogs",
                column: "BudgetCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Id",
                table: "Categories",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LineComment_BudgetLineId1",
                table: "LineComment",
                column: "BudgetLineId1");

            migrationBuilder.CreateIndex(
                name: "IX_LineComment_Id",
                table: "LineComment",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LineComment_BudgetLineLogId_BudgetLineLogLogInstance",
                table: "LineComment",
                columns: new[] { "BudgetLineLogId", "BudgetLineLogLogInstance" });

            migrationBuilder.CreateIndex(
                name: "IX_LineCommentLog_BudgetLineId1",
                table: "LineCommentLog",
                column: "BudgetLineId1");

            migrationBuilder.CreateIndex(
                name: "IX_Periods_Id",
                table: "Periods",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactPersons_Name",
                table: "ContactPersons",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactPersons_OperatorId1",
                table: "ContactPersons",
                column: "OperatorId1");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPersonLogs_OperatorId1",
                table: "ContactPersonLogs",
                column: "OperatorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Operators_Name",
                table: "Operators",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Operators_OperatorTypeId1",
                table: "Operators",
                column: "OperatorTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Operators_OperatorTypeLogId_OperatorTypeLogLogInstance",
                table: "Operators",
                columns: new[] { "OperatorTypeLogId", "OperatorTypeLogLogInstance" });

            migrationBuilder.CreateIndex(
                name: "IX_OperatorLogs_ContactPersonId1",
                table: "OperatorLogs",
                column: "ContactPersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorTypes_Id",
                table: "OperatorTypes",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actuals");

            migrationBuilder.DropTable(
                name: "ActualLogs");

            migrationBuilder.DropTable(
                name: "BudgetCodes");

            migrationBuilder.DropTable(
                name: "BudgetCodeLogs");

            migrationBuilder.DropTable(
                name: "CategoryLogs");

            migrationBuilder.DropTable(
                name: "LineComment");

            migrationBuilder.DropTable(
                name: "LineCommentLog");

            migrationBuilder.DropTable(
                name: "Periods");

            migrationBuilder.DropTable(
                name: "PeriodLogs");

            migrationBuilder.DropTable(
                name: "ContactPersonLogs");

            migrationBuilder.DropTable(
                name: "OperatorLogs");

            migrationBuilder.DropTable(
                name: "BudgetLineLogs");

            migrationBuilder.DropTable(
                name: "BudgetLines");

            migrationBuilder.DropTable(
                name: "ContactPersons");

            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "BudgetLogs");

            migrationBuilder.DropTable(
                name: "Operators");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "OperatorTypes");

            migrationBuilder.DropTable(
                name: "OperatorTypeLogs");
        }
    }
}
