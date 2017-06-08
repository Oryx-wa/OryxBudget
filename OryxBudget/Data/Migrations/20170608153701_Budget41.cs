using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Budget41 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Commitee",
                table: "ContactPersonLogs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Commitee",
                table: "ContactPersons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CodeCategory",
                table: "BudgetCodeLogs",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "BudgetCodeLogs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CodeCategory",
                table: "BudgetCodes",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "BudgetCodes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WorkProgramCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BudgetCode = table.Column<string>(nullable: true),
                    BudgetCodeId = table.Column<Guid>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkProgramCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkProgramCodes_BudgetCodes_BudgetCodeId",
                        column: x => x.BudgetCodeId,
                        principalTable: "BudgetCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkProgramCodeLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LogInstance = table.Column<int>(nullable: false),
                    BudgetCode = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkProgramCodeLogs", x => new { x.Id, x.LogInstance });
                    table.UniqueConstraint("AK_WorkProgramCodeLogs_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrillingCosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BudgetAmountFC = table.Column<decimal>(nullable: false),
                    BudgetAmountLC = table.Column<decimal>(nullable: false),
                    BudgetAmountUSD = table.Column<decimal>(nullable: false),
                    BudgetCode = table.Column<string>(maxLength: 50, nullable: true),
                    BudgetLineId = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 255, nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    TypeId = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 50, nullable: true),
                    WellId = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrillingCosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrillingCostLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BudgetAmountFC = table.Column<decimal>(nullable: false),
                    BudgetAmountLC = table.Column<decimal>(nullable: false),
                    BudgetAmountUSD = table.Column<decimal>(nullable: false),
                    BudgetCode = table.Column<string>(maxLength: 50, nullable: true),
                    BudgetLineId = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LogInstance = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 255, nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    TypeId = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 50, nullable: true),
                    WellId = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrillingCostLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrillingCostTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    Type = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrillingCostTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrillingCostTypeLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    LogInstance = table.Column<int>(nullable: false),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    Type = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrillingCostTypeLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExplorationWorkPrograms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BudgetAmountFC = table.Column<decimal>(nullable: false),
                    BudgetAmountLC = table.Column<decimal>(nullable: false),
                    BudgetAmountUSD = table.Column<decimal>(nullable: false),
                    BudgetCode = table.Column<string>(nullable: true),
                    BudgetLineId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 255, nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 50, nullable: true),
                    WorkProgramTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExplorationWorkPrograms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExplorationWorkProgramLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BudgetAmountFC = table.Column<decimal>(nullable: false),
                    BudgetAmountLC = table.Column<decimal>(nullable: false),
                    BudgetAmountUSD = table.Column<decimal>(nullable: false),
                    BudgetCode = table.Column<string>(nullable: true),
                    BudgetLineId = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LogInstance = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 255, nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false),
                    WorkProgramTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExplorationWorkProgramLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkProgramTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    Type = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkProgramTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkProgramTypeLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    LogInstance = table.Column<int>(nullable: false),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    Type = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkProgramTypeLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NapimsContacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Committee = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Status = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    UserId = table.Column<Guid>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NapimsContacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NapimsContactLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LogInstance = table.Column<int>(nullable: false),
                    Committee = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Status = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NapimsContactLogs", x => new { x.Id, x.LogInstance });
                });

            migrationBuilder.CreateTable(
                name: "OilBlocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    OperatorId = table.Column<Guid>(nullable: false),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OilBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OilBlocks_Operators_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OilBlockLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LogInstance = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    OperatorId = table.Column<Guid>(nullable: false),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OilBlockLogs", x => new { x.Id, x.LogInstance });
                    table.UniqueConstraint("AK_OilBlockLogs_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FieldLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Area = table.Column<long>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    ConessionId = table.Column<string>(maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Dimension = table.Column<string>(maxLength: 50, nullable: true),
                    LogInstance = table.Column<int>(nullable: false),
                    PlannedVolume = table.Column<long>(nullable: true),
                    RatePerVolume = table.Column<decimal>(nullable: true),
                    Remarks = table.Column<string>(maxLength: 255, nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    TotalCost = table.Column<decimal>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WellLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    FieldId = table.Column<string>(maxLength: 50, nullable: true),
                    Location = table.Column<string>(maxLength: 150, nullable: true),
                    LogInstance = table.Column<int>(nullable: false),
                    RigRate = table.Column<decimal>(nullable: true),
                    SpudDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    SupportService = table.Column<decimal>(nullable: true),
                    Terrain = table.Column<string>(maxLength: 100, nullable: true),
                    TotalCost = table.Column<decimal>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 50, nullable: true),
                    WellTypeId = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WellLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Area = table.Column<long>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    ConcessionId = table.Column<Guid>(nullable: true),
                    ConessionId = table.Column<string>(maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Dimension = table.Column<string>(maxLength: 50, nullable: true),
                    PlannedVolume = table.Column<long>(nullable: true),
                    RatePerVolume = table.Column<decimal>(nullable: true),
                    Remarks = table.Column<string>(maxLength: 255, nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    TotalCost = table.Column<decimal>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_OilBlocks_ConcessionId",
                        column: x => x.ConcessionId,
                        principalTable: "OilBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wells",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    FieldId = table.Column<string>(maxLength: 50, nullable: true),
                    FieldId1 = table.Column<Guid>(nullable: true),
                    Location = table.Column<string>(maxLength: 150, nullable: true),
                    RigRate = table.Column<decimal>(nullable: true),
                    SpudDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    SupportService = table.Column<decimal>(nullable: true),
                    Terrain = table.Column<string>(maxLength: 100, nullable: true),
                    TotalCost = table.Column<decimal>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UserSign = table.Column<string>(maxLength: 50, nullable: true),
                    WellTypeId = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wells_Fields_FieldId1",
                        column: x => x.FieldId1,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkProgramCodes_BudgetCodeId",
                table: "WorkProgramCodes",
                column: "BudgetCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkProgramCodes_Id",
                table: "WorkProgramCodes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NapimsContacts_Id",
                table: "NapimsContacts",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OilBlocks_Id",
                table: "OilBlocks",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OilBlocks_OperatorId",
                table: "OilBlocks",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_ConcessionId",
                table: "Fields",
                column: "ConcessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Wells_FieldId1",
                table: "Wells",
                column: "FieldId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkProgramCodes");

            migrationBuilder.DropTable(
                name: "WorkProgramCodeLogs");

            migrationBuilder.DropTable(
                name: "DrillingCosts");

            migrationBuilder.DropTable(
                name: "DrillingCostLogs");

            migrationBuilder.DropTable(
                name: "DrillingCostTypes");

            migrationBuilder.DropTable(
                name: "DrillingCostTypeLogs");

            migrationBuilder.DropTable(
                name: "ExplorationWorkPrograms");

            migrationBuilder.DropTable(
                name: "ExplorationWorkProgramLogs");

            migrationBuilder.DropTable(
                name: "WorkProgramTypes");

            migrationBuilder.DropTable(
                name: "WorkProgramTypeLogs");

            migrationBuilder.DropTable(
                name: "NapimsContacts");

            migrationBuilder.DropTable(
                name: "NapimsContactLogs");

            migrationBuilder.DropTable(
                name: "OilBlockLogs");

            migrationBuilder.DropTable(
                name: "FieldLogs");

            migrationBuilder.DropTable(
                name: "Wells");

            migrationBuilder.DropTable(
                name: "WellLogs");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "OilBlocks");

            migrationBuilder.DropColumn(
                name: "Commitee",
                table: "ContactPersonLogs");

            migrationBuilder.DropColumn(
                name: "Commitee",
                table: "ContactPersons");

            migrationBuilder.DropColumn(
                name: "CodeCategory",
                table: "BudgetCodeLogs");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "BudgetCodeLogs");

            migrationBuilder.DropColumn(
                name: "CodeCategory",
                table: "BudgetCodes");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "BudgetCodes");
        }
    }
}
