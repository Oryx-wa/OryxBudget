using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Data;
using Entities.Budgets;

namespace Data.Migrations
{
    [DbContext(typeof(OryxBudgetContext))]
    [Migration("20170529141319_Budget35")]
    partial class Budget35
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Budgets.Actual", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BudgetId");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("Description")
                        .HasMaxLength(150);

                    b.Property<decimal>("FinalActualFC");

                    b.Property<decimal>("FinalActualLC");

                    b.Property<decimal>("FinalActualUSD");

                    b.Property<int>("LineStatus");

                    b.Property<decimal>("MalComActualFC");

                    b.Property<decimal>("MalComActualLC");

                    b.Property<decimal>("MalComActualUSD");

                    b.Property<decimal>("OpActualFC");

                    b.Property<decimal>("OpActualLC");

                    b.Property<decimal>("OpActualLCInUSD");

                    b.Property<decimal>("OpActualUSD");

                    b.Property<DateTime>("PeriodEnd");

                    b.Property<string>("PeriodId");

                    b.Property<DateTime>("PeriodStart");

                    b.Property<string>("Remarks")
                        .HasMaxLength(150);

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<decimal>("SubComActualFC");

                    b.Property<decimal>("SubComActualLC");

                    b.Property<decimal>("SubComActualUSD");

                    b.Property<decimal>("TecComActualFC");

                    b.Property<decimal>("TecComActualLC");

                    b.Property<decimal>("TecComActualUSD");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Actuals");
                });

            modelBuilder.Entity("Entities.Budgets.ActualLog", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<int>("LogInstance");

                    b.Property<decimal>("AmountLC");

                    b.Property<decimal>("AmountLCInUSD");

                    b.Property<decimal>("AmountUSD");

                    b.Property<Guid>("BudgetId");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description")
                        .HasMaxLength(150);

                    b.Property<DateTime>("PeriodEnd");

                    b.Property<string>("PeriodId");

                    b.Property<DateTime>("PeriodStart");

                    b.Property<string>("Remarks")
                        .HasMaxLength(150);

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<decimal>("TotalAmount");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id", "LogInstance");

                    b.ToTable("ActualLogs");
                });

            modelBuilder.Entity("Entities.Budgets.Attachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BudgetId");

                    b.Property<Guid?>("BudgetLineId");

                    b.Property<string>("Code")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreateDate");

                    b.Property<byte[]>("FileData");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("Entities.Budgets.AttachmentLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BudgetId");

                    b.Property<Guid?>("BudgetLineId");

                    b.Property<string>("Code")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreateDate");

                    b.Property<byte[]>("FileData");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("LogInstance");

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("AttachmentLogs");
                });

            modelBuilder.Entity("Entities.Budgets.Budget", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActualStatus");

                    b.Property<string>("AdditionalStatement")
                        .HasMaxLength(300);

                    b.Property<string>("BudgetLineCategoryId");

                    b.Property<int>("BudgetStatus");

                    b.Property<string>("CategoryId");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<decimal>("FinalActualFC");

                    b.Property<decimal>("FinalActualLC");

                    b.Property<decimal>("FinalActualUSD");

                    b.Property<decimal>("FinalBudgetFC");

                    b.Property<decimal>("FinalBudgetLC");

                    b.Property<decimal>("FinalBudgetUSD");

                    b.Property<decimal>("MalComActualFC");

                    b.Property<decimal>("MalComActualLC");

                    b.Property<decimal>("MalComActualUSD");

                    b.Property<decimal>("MalComBudgetFC");

                    b.Property<decimal>("MalComBudgetLC");

                    b.Property<decimal>("MalComBudgetUSD");

                    b.Property<decimal>("OpActualFC");

                    b.Property<decimal>("OpActualLC");

                    b.Property<decimal>("OpActualUSD");

                    b.Property<decimal>("OpBudgetFC");

                    b.Property<decimal>("OpBudgetLC");

                    b.Property<decimal>("OpBudgetUSD");

                    b.Property<string>("OperatorId")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PeriodId")
                        .HasMaxLength(50);

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<decimal>("SubComActualFC");

                    b.Property<decimal>("SubComActualLC");

                    b.Property<decimal>("SubComActualUSD");

                    b.Property<decimal>("SubComBudgetFC");

                    b.Property<decimal>("SubComBudgetLC");

                    b.Property<decimal>("SubComBudgetUSD");

                    b.Property<decimal>("TecComActualFC");

                    b.Property<decimal>("TecComActualLC");

                    b.Property<decimal>("TecComActualUSD");

                    b.Property<decimal>("TecComBudgetFC");

                    b.Property<decimal>("TecComBudgetLC");

                    b.Property<decimal>("TecComBudgetUSD");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("Entities.Budgets.BudgetCode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Active")
                        .HasMaxLength(1);

                    b.Property<string>("CategoryId")
                        .HasMaxLength(50);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<string>("FatherNum")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Level1")
                        .HasMaxLength(20);

                    b.Property<string>("Level2")
                        .HasMaxLength(30);

                    b.Property<string>("Postable")
                        .HasMaxLength(1);

                    b.Property<string>("SecondDescription")
                        .HasMaxLength(1000);

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("BudgetCodes");
                });

            modelBuilder.Entity("Entities.Budgets.BudgetCodeLog", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<int>("LogInstance");

                    b.Property<string>("Active");

                    b.Property<string>("CategoryId")
                        .HasMaxLength(50);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<string>("FatherNum")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Level1")
                        .HasMaxLength(20);

                    b.Property<string>("Level2")
                        .HasMaxLength(30);

                    b.Property<string>("Postable")
                        .HasMaxLength(1);

                    b.Property<string>("SecondDescription")
                        .HasMaxLength(1000);

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id", "LogInstance");

                    b.HasAlternateKey("Id");

                    b.ToTable("BudgetCodeLogs");
                });

            modelBuilder.Entity("Entities.Budgets.BudgetLine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApprovalStatus")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<Guid>("BudgetId");

                    b.Property<Guid?>("BudgetLogId");

                    b.Property<int?>("BudgetLogLogInstance");

                    b.Property<string>("CategoryId");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<decimal>("FinalBudgetFC");

                    b.Property<decimal>("FinalBudgetLC");

                    b.Property<decimal>("FinalBudgetUSD");

                    b.Property<int>("LineStatus")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<decimal>("MalComBudgetFC");

                    b.Property<decimal>("MalComBudgetLC");

                    b.Property<decimal>("MalComBudgetUSD");

                    b.Property<decimal>("OpBudgetFC");

                    b.Property<decimal>("OpBudgetLC");

                    b.Property<decimal>("OpBudgetLCInUSD");

                    b.Property<decimal>("OpBudgetUSD");

                    b.Property<int?>("RowNumber");

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<decimal>("SubComBudgetFC");

                    b.Property<decimal>("SubComBudgetLC");

                    b.Property<decimal>("SubComBudgetUSD");

                    b.Property<decimal>("TecComBudgetFC");

                    b.Property<decimal>("TecComBudgetLC");

                    b.Property<decimal>("TecComBudgetUSD");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("BudgetLogId", "BudgetLogLogInstance");

                    b.ToTable("BudgetLines");
                });

            modelBuilder.Entity("Entities.Budgets.BudgetLineLog", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<int>("LogInstance");

                    b.Property<int>("ApprovalStatus");

                    b.Property<Guid>("BudgetId");

                    b.Property<string>("CategoryId");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<decimal>("FinalBudgetFC");

                    b.Property<decimal>("FinalBudgetLC");

                    b.Property<decimal>("FinalBudgetUSD");

                    b.Property<int>("LineStatus");

                    b.Property<decimal>("MalComBudgetFC");

                    b.Property<decimal>("MalComBudgetLC");

                    b.Property<decimal>("MalComBudgetUSD");

                    b.Property<decimal>("OpBudgetFC");

                    b.Property<decimal>("OpBudgetLC");

                    b.Property<decimal>("OpBudgetLCInUSD");

                    b.Property<decimal>("OpBudgetUSD");

                    b.Property<int?>("RowNumber");

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<decimal>("SubComBudgetFC");

                    b.Property<decimal>("SubComBudgetLC");

                    b.Property<decimal>("SubComBudgetUSD");

                    b.Property<decimal>("TecComBudgetFC");

                    b.Property<decimal>("TecComBudgetLC");

                    b.Property<decimal>("TecComBudgetUSD");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id", "LogInstance");

                    b.ToTable("BudgetLineLogs");
                });

            modelBuilder.Entity("Entities.Budgets.BudgetLog", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<int>("LogInstance");

                    b.Property<int>("ActualStatus");

                    b.Property<string>("AdditionalStatement")
                        .HasMaxLength(300);

                    b.Property<int>("BudgetStatus");

                    b.Property<string>("CategoryId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<decimal>("FinalActualFC");

                    b.Property<decimal>("FinalActualLC");

                    b.Property<decimal>("FinalActualUSD");

                    b.Property<decimal>("FinalBudgetFC");

                    b.Property<decimal>("FinalBudgetLC");

                    b.Property<decimal>("FinalBudgetUSD");

                    b.Property<decimal>("MalComActualFC");

                    b.Property<decimal>("MalComActualLC");

                    b.Property<decimal>("MalComActualUSD");

                    b.Property<decimal>("MalComBudgetFC");

                    b.Property<decimal>("MalComBudgetLC");

                    b.Property<decimal>("MalComBudgetUSD");

                    b.Property<decimal>("OpActualFC");

                    b.Property<decimal>("OpActualLC");

                    b.Property<decimal>("OpActualUSD");

                    b.Property<decimal>("OpBudgetFC");

                    b.Property<decimal>("OpBudgetLC");

                    b.Property<decimal>("OpBudgetUSD");

                    b.Property<string>("OperatorId")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PeriodId");

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<decimal>("SubComActualFC");

                    b.Property<decimal>("SubComActualLC");

                    b.Property<decimal>("SubComActualUSD");

                    b.Property<decimal>("SubComBudgetFC");

                    b.Property<decimal>("SubComBudgetLC");

                    b.Property<decimal>("SubComBudgetUSD");

                    b.Property<decimal>("TecComActualFC");

                    b.Property<decimal>("TecComActualLC");

                    b.Property<decimal>("TecComActualUSD");

                    b.Property<decimal>("TecComBudgetFC");

                    b.Property<decimal>("TecComBudgetLC");

                    b.Property<decimal>("TecComBudgetUSD");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id", "LogInstance");

                    b.ToTable("BudgetLogs");
                });

            modelBuilder.Entity("Entities.Budgets.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Entities.Budgets.CategoryLog", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<int>("LogInstance");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id", "LogInstance");

                    b.HasAlternateKey("Id");

                    b.ToTable("CategoryLogs");
                });

            modelBuilder.Entity("Entities.Budgets.LineComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BudgetId");

                    b.Property<string>("Code");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(355);

                    b.Property<int>("CommentStatus");

                    b.Property<int>("CommentType");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("UserEmail");

                    b.Property<string>("UserName");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("LineComment");
                });

            modelBuilder.Entity("Entities.Budgets.LineCommentLog", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<int>("LogInstance");

                    b.Property<Guid?>("BudgetId");

                    b.Property<string>("Code");

                    b.Property<string>("Comment")
                        .HasMaxLength(355);

                    b.Property<int>("CommentStatus");

                    b.Property<int>("CommentType");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UserEmail");

                    b.Property<string>("UserName");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UserType")
                        .HasMaxLength(15);

                    b.HasKey("Id", "LogInstance");

                    b.ToTable("LineCommentLog");
                });

            modelBuilder.Entity("Entities.Budgets.Period", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Periods");
                });

            modelBuilder.Entity("Entities.Budgets.PeriodLog", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<int>("LogInstance");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id", "LogInstance");

                    b.ToTable("PeriodLogs");
                });

            modelBuilder.Entity("Entities.Budgets.StatusHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BudgetId");

                    b.Property<string>("Code");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<int>("ItemCodeStatus");

                    b.Property<int>("ItemStatus");

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("StatusHistory");
                });

            modelBuilder.Entity("Entities.Budgets.StatusHistoryLog", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<int>("LogInstance");

                    b.Property<Guid>("BudgetId");

                    b.Property<string>("Code");

                    b.Property<DateTime>("CreateDate");

                    b.Property<int>("ItemCodeStatus");

                    b.Property<int>("ItemStatus");

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id", "LogInstance");

                    b.ToTable("StatusHistoryLog");
                });

            modelBuilder.Entity("Entities.Operators.ContactPerson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<Guid>("OperatorId")
                        .HasMaxLength(50);

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("OperatorId");

                    b.ToTable("ContactPersons");
                });

            modelBuilder.Entity("Entities.Operators.ContactPersonLog", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<int>("LogInstance");

                    b.Property<DateTime>("CreateDate")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("OperatorId")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id", "LogInstance");

                    b.ToTable("ContactPersonLogs");
                });

            modelBuilder.Entity("Entities.Operators.Operator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()")
                        .HasMaxLength(50);

                    b.Property<string>("ImageSrc")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("OperatorTypeId")
                        .HasMaxLength(50);

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Operators");
                });

            modelBuilder.Entity("Entities.Operators.OperatorLog", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<int>("LogInstance");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreateDate")
                        .HasMaxLength(50);

                    b.Property<string>("ImageSrc")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("OperatorTypeId")
                        .HasMaxLength(50);

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id", "LogInstance");

                    b.ToTable("OperatorLogs");
                });

            modelBuilder.Entity("Entities.Operators.OperatorType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("OperatorTypes");
                });

            modelBuilder.Entity("Entities.Operators.OperatorTypeLog", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<int>("LogInstance");

                    b.Property<DateTime>("CreateDate")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id", "LogInstance");

                    b.ToTable("OperatorTypeLogs");
                });

            modelBuilder.Entity("Entities.Budgets.Actual", b =>
                {
                    b.HasOne("Entities.Budgets.Budget")
                        .WithMany("Actuals")
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.Budgets.BudgetLine", b =>
                {
                    b.HasOne("Entities.Budgets.Budget")
                        .WithMany("BudgetLines")
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.Budgets.BudgetLog")
                        .WithMany("BudgetLines")
                        .HasForeignKey("BudgetLogId", "BudgetLogLogInstance");
                });

            modelBuilder.Entity("Entities.Budgets.LineComment", b =>
                {
                    b.HasOne("Entities.Budgets.Budget")
                        .WithMany("LineComments")
                        .HasForeignKey("BudgetId");
                });

            modelBuilder.Entity("Entities.Operators.ContactPerson", b =>
                {
                    b.HasOne("Entities.Operators.Operator")
                        .WithMany("ContactPersons")
                        .HasForeignKey("OperatorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
