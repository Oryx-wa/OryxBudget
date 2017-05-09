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
    [Migration("20170508112949_Budget2")]
    partial class Budget2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Budgets.Actual", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BudgetId")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("Description")
                        .HasMaxLength(150);

                    b.Property<string>("Remarks")
                        .HasMaxLength(150);

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<decimal>("TotalAmount");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Actuals");
                });

            modelBuilder.Entity("Entities.Budgets.ActualLog", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<int>("LogInstance");

                    b.Property<string>("BudgetId")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description")
                        .HasMaxLength(150);

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

            modelBuilder.Entity("Entities.Budgets.Budget", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionalStatement")
                        .HasMaxLength(300);

                    b.Property<Guid?>("BudgetCategoryId");

                    b.Property<string>("BudgetLineCategoryId");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("OperatorId")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PeriodId")
                        .HasMaxLength(50);

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<decimal>("TotalBudgetAmount");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("BudgetCategoryId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("Entities.Budgets.BudgetCode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Active");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<Guid?>("CategoryId1");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("Description")
                        .HasMaxLength(150);

                    b.Property<string>("FatherNum")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Postable")
                        .HasMaxLength(50);

                    b.Property<string>("SecondDescription")
                        .HasMaxLength(150);

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId1");

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
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<Guid?>("CategoryId1");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description")
                        .HasMaxLength(150);

                    b.Property<string>("FatherNum")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Postable")
                        .HasMaxLength(50);

                    b.Property<string>("SecondDescription")
                        .HasMaxLength(150);

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id", "LogInstance");

                    b.HasAlternateKey("Id");

                    b.HasIndex("CategoryId1");

                    b.ToTable("BudgetCodeLogs");
                });

            modelBuilder.Entity("Entities.Budgets.BudgetLine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("ActualAmount");

                    b.Property<decimal>("BudgetAmount");

                    b.Property<string>("BudgetId")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<Guid?>("BudgetId1");

                    b.Property<Guid?>("BudgetLineCategoryId");

                    b.Property<Guid?>("BudgetLogId");

                    b.Property<int?>("BudgetLogLogInstance");

                    b.Property<int>("CategoryId");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("RowNumber");

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("BudgetId1");

                    b.HasIndex("BudgetLineCategoryId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("BudgetLogId", "BudgetLogLogInstance");

                    b.ToTable("BudgetLines");
                });

            modelBuilder.Entity("Entities.Budgets.BudgetLineLog", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<int>("LogInstance");

                    b.Property<decimal>("ActualAmount");

                    b.Property<decimal>("BudgetAmount");

                    b.Property<string>("BudgetId")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<Guid?>("BudgetId1");

                    b.Property<int>("CategoryId");

                    b.Property<Guid?>("CategoryId1");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("RowNumber");

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id", "LogInstance");

                    b.HasIndex("BudgetId1");

                    b.HasIndex("CategoryId1");

                    b.ToTable("BudgetLineLogs");
                });

            modelBuilder.Entity("Entities.Budgets.BudgetLog", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<int>("LogInstance");

                    b.Property<string>("AdditionalStatement")
                        .HasMaxLength(300);

                    b.Property<Guid?>("BudgetCategoryId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("OperatorId")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PeriodId");

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<decimal>("TotalBudgetAmount");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id", "LogInstance");

                    b.HasIndex("BudgetCategoryId");

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

                    b.Property<string>("BudgetLineId")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<Guid?>("BudgetLineId1");

                    b.Property<Guid?>("BudgetLineLogId");

                    b.Property<int?>("BudgetLineLogLogInstance");

                    b.Property<string>("Comment")
                        .HasMaxLength(355);

                    b.Property<int>("CommentStatus");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("BudgetLineId1");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("BudgetLineLogId", "BudgetLineLogLogInstance");

                    b.ToTable("LineComment");
                });

            modelBuilder.Entity("Entities.Budgets.LineCommentLog", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<int>("LogInstance");

                    b.Property<string>("BudgetLineId")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<Guid?>("BudgetLineId1");

                    b.Property<string>("Comment")
                        .HasMaxLength(355);

                    b.Property<int>("CommentStatus");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id", "LogInstance");

                    b.HasAlternateKey("Id");

                    b.HasIndex("BudgetLineId1");

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

                    b.Property<string>("OperatorId")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<Guid?>("OperatorId1");

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

                    b.HasIndex("OperatorId1");

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

                    b.Property<Guid?>("OperatorId1");

                    b.Property<string>("Status")
                        .HasMaxLength(1);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UserSign")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id", "LogInstance");

                    b.HasIndex("OperatorId1");

                    b.ToTable("ContactPersonLogs");
                });

            modelBuilder.Entity("Entities.Operators.Operator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("ContactPersonId")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getDate()")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("OperatorTypeId")
                        .HasMaxLength(50);

                    b.Property<Guid?>("OperatorTypeId1");

                    b.Property<Guid?>("OperatorTypeLogId");

                    b.Property<int?>("OperatorTypeLogLogInstance");

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

                    b.HasIndex("OperatorTypeId1");

                    b.HasIndex("OperatorTypeLogId", "OperatorTypeLogLogInstance");

                    b.ToTable("Operators");
                });

            modelBuilder.Entity("Entities.Operators.OperatorLog", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<int>("LogInstance");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("ContactPersonId")
                        .HasMaxLength(50);

                    b.Property<Guid?>("ContactPersonId1");

                    b.Property<DateTime>("CreateDate")
                        .HasMaxLength(50);

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

                    b.HasIndex("ContactPersonId1");

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

            modelBuilder.Entity("Entities.Budgets.Budget", b =>
                {
                    b.HasOne("Entities.Budgets.Category", "BudgetCategory")
                        .WithMany()
                        .HasForeignKey("BudgetCategoryId");
                });

            modelBuilder.Entity("Entities.Budgets.BudgetCode", b =>
                {
                    b.HasOne("Entities.Budgets.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId1");
                });

            modelBuilder.Entity("Entities.Budgets.BudgetCodeLog", b =>
                {
                    b.HasOne("Entities.Budgets.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId1");
                });

            modelBuilder.Entity("Entities.Budgets.BudgetLine", b =>
                {
                    b.HasOne("Entities.Budgets.Budget", "Budget")
                        .WithMany("BudgetLines")
                        .HasForeignKey("BudgetId1");

                    b.HasOne("Entities.Budgets.Category", "BudgetLineCategory")
                        .WithMany()
                        .HasForeignKey("BudgetLineCategoryId");

                    b.HasOne("Entities.Budgets.BudgetLog")
                        .WithMany("BudgetLines")
                        .HasForeignKey("BudgetLogId", "BudgetLogLogInstance");
                });

            modelBuilder.Entity("Entities.Budgets.BudgetLineLog", b =>
                {
                    b.HasOne("Entities.Budgets.Budget", "Budget")
                        .WithMany()
                        .HasForeignKey("BudgetId1");

                    b.HasOne("Entities.Budgets.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId1");
                });

            modelBuilder.Entity("Entities.Budgets.BudgetLog", b =>
                {
                    b.HasOne("Entities.Budgets.Category", "BudgetCategory")
                        .WithMany()
                        .HasForeignKey("BudgetCategoryId");
                });

            modelBuilder.Entity("Entities.Budgets.LineComment", b =>
                {
                    b.HasOne("Entities.Budgets.BudgetLine", "BudgetLine")
                        .WithMany("LineComments")
                        .HasForeignKey("BudgetLineId1");

                    b.HasOne("Entities.Budgets.BudgetLineLog")
                        .WithMany("LineComments")
                        .HasForeignKey("BudgetLineLogId", "BudgetLineLogLogInstance");
                });

            modelBuilder.Entity("Entities.Budgets.LineCommentLog", b =>
                {
                    b.HasOne("Entities.Budgets.BudgetLine", "BudgetLine")
                        .WithMany()
                        .HasForeignKey("BudgetLineId1");
                });

            modelBuilder.Entity("Entities.Operators.ContactPerson", b =>
                {
                    b.HasOne("Entities.Operators.Operator", "Operator")
                        .WithMany()
                        .HasForeignKey("OperatorId1");
                });

            modelBuilder.Entity("Entities.Operators.ContactPersonLog", b =>
                {
                    b.HasOne("Entities.Operators.Operator", "Operator")
                        .WithMany()
                        .HasForeignKey("OperatorId1");
                });

            modelBuilder.Entity("Entities.Operators.Operator", b =>
                {
                    b.HasOne("Entities.Operators.OperatorType")
                        .WithMany("Operators")
                        .HasForeignKey("OperatorTypeId1");

                    b.HasOne("Entities.Operators.OperatorTypeLog")
                        .WithMany("Operators")
                        .HasForeignKey("OperatorTypeLogId", "OperatorTypeLogLogInstance");
                });

            modelBuilder.Entity("Entities.Operators.OperatorLog", b =>
                {
                    b.HasOne("Entities.Operators.ContactPerson", "ContactPerson")
                        .WithMany()
                        .HasForeignKey("ContactPersonId1");
                });
        }
    }
}
