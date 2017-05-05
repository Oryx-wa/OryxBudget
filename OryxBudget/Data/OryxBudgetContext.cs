using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.Budgets;
using Data.Configurations;
using Entities.Operators;

namespace Data
{
    public class OryxBudgetContext : DbContext
    {
        public OryxBudgetContext(DbContextOptions<OryxBudgetContext> options)
        : base(options)
        {
              Database.EnsureCreated();
        }

        #region EntitySets
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<BudgetLog> BudgetLogs { get; set; }

        public DbSet<BudgetLine> BudgetLines { get; set; }
        public DbSet<BudgetLineLog> BudgetLineLogs { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryLog> CategoryLogs { get; set; }

        public DbSet<Period> Periods { get; set; }
        public DbSet<PeriodLog> PeriodLogs { get; set; }

        public DbSet<Actual> Actuals { get; set; }
        public DbSet<ActualLog> ActualLogs { get; set; }

        public DbSet<BudgetCode> BudgetCodes { get; set; }
        public DbSet<BudgetCodeLog> BudgetCodeLogs { get; set; }

        //Operator
        public DbSet<Operator> Operators { get; set; }
        public DbSet<OperatorLog> OperatorLogs { get; set; }

        public DbSet<OperatorType> OperatorTypes { get; set; }
        public DbSet<OperatorTypeLog> OperatorTypeLogs { get; set; }

        public DbSet<ContactPerson> ContactPersons { get; set; }
        public DbSet<ContactPersonLog> ContactPersonLogs { get; set; }


        #endregion

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

          //  builder.Entity<HRDefinitionItem>()
          // .HasDiscriminator();
          // .HasValue()
           //.HasValue<LGA>("hrdefinitionItem_lga");

            // BudgetConfiguration.ModelConfiguration(ref builder);
            
            BudgetConfiguration.ModelConfiguration(ref builder);
            OperatorConfiguration.ModelConfiguration(ref builder);



            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            //foreach (var entity in builder.Model.GetEntityTypes())
            //{
            //    entity.Relational().TableName = entity.DisplayName();
            //}

        }


    }
}
