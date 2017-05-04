﻿ using Microsoft.EntityFrameworkCore;
using Entities.Budgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class BudgetConfiguration
    {
        public static void ModelConfiguration(ref ModelBuilder builder)
        {

            //Budget
            builder.Entity<Budget>().HasIndex(m => new { m.Id }).IsUnique();
            builder.Entity<Budget>().Property(m => m.CreateDate).HasDefaultValueSql("getDate()");
            builder.Entity<Budget>().Property(m => m.UpdateDate).HasDefaultValueSql("getDate()");
            builder.Entity<BudgetLog>().HasKey(c => new {
                c.Id,
                c.LogInstance
            });


            //BudgetLine
            builder.Entity<BudgetLine>().HasIndex(m => new { m.Id }).IsUnique();
            builder.Entity<BudgetLine>().Property(m => m.CreateDate).HasDefaultValueSql("getDate()");
            builder.Entity<BudgetLine>().Property(m => m.UpdateDate).HasDefaultValueSql("getDate()");
            builder.Entity<BudgetLineLog>().HasKey(c => new {
                c.Id,
                c.LogInstance
            });


            //BudgetLineCategory
            builder.Entity<Category>().HasIndex(m => new { m.Id }).IsUnique();
            builder.Entity<Category>().Property(m => m.CreateDate).HasDefaultValueSql("getDate()");
            builder.Entity<Category>().Property(m => m.UpdateDate).HasDefaultValueSql("getDate()");
            builder.Entity<CategoryLog>().HasKey(c => new { c.Id, c.LogInstance });

            //LineComment
            builder.Entity<LineComment>().HasIndex(m => new { m.Id }).IsUnique();
            builder.Entity<LineComment>().Property(m => m.CreateDate).HasDefaultValueSql("getDate()");
            builder.Entity<LineComment>().Property(m => m.UpdateDate).HasDefaultValueSql("getDate()");
            builder.Entity<LineCommentLog>().HasKey(c => new { c.Id, c.LogInstance });

            //Period
            builder.Entity<Period>().HasIndex(m => new { m.Id }).IsUnique();
            builder.Entity<Period>().Property(m => m.CreateDate).HasDefaultValueSql("getDate()");
            builder.Entity<Period>().Property(m => m.UpdateDate).HasDefaultValueSql("getDate()");
            builder.Entity<PeriodLog>().HasKey(c => new { c.Id, c.LogInstance });

            //Period
            builder.Entity<Actual>().HasIndex(m => new { m.Id }).IsUnique();
            builder.Entity<Actual>().Property(m => m.CreateDate).HasDefaultValueSql("getDate()");
            builder.Entity<Actual>().Property(m => m.UpdateDate).HasDefaultValueSql("getDate()");
            builder.Entity<ActualLog>().HasKey(c => new { c.Id, c.LogInstance });

        }
    }
}