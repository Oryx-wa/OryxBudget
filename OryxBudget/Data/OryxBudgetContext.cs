using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.Budgets;
using Data.Configurations;


namespace Data
{
    public class OryxBudgetContext : DbContext
    {
        public OryxBudgetContext(DbContextOptions<OryxBudgetContext> options)
        : base(options)
        {
            // Database.EnsureCreated();
        }

        #region EntitySets
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<BudgetLog> BudgetLogs { get; set; }

        public DbSet<BudgetLine> BudgetLines { get; set; }
        public DbSet<BudgetLineLog> BudgetLineLogs { get; set; }

        public DbSet<BudgetLineCategory> BudgetLineCategorys { get; set; }
        public DbSet<BudgetLineCategoryLog> BudgetLineCategoryLogs { get; set; }

        public DbSet<Period> Periods { get; set; }
        public DbSet<PeriodLog> PeriodLogs { get; set; }


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
