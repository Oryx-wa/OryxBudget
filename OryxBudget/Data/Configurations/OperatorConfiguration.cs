﻿using Entities.Operators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class OperatorConfiguration
    {
        public static void ModelConfiguration(ref ModelBuilder builder)

        {

            //Operator
            builder.Entity<Operator>().HasIndex(m => new { m.Name }).IsUnique();
            builder.Entity<Operator>().Property(m => m.CreateDate).HasDefaultValueSql("getDate()");
            builder.Entity<Operator>().Property(m => m.UpdateDate).HasDefaultValueSql("getDate()");
            builder.Entity<OperatorLog>().HasKey(c => new
            {
                c.Id,
                c.LogInstance
            });


            //OperatorType
            builder.Entity<OperatorType>().HasIndex(m => new { m.Id }).IsUnique();
            builder.Entity<OperatorType>().Property(m => m.CreateDate).HasDefaultValueSql("getDate()");
            builder.Entity<OperatorType>().Property(m => m.UpdateDate).HasDefaultValueSql("getDate()");
            builder.Entity<OperatorTypeLog>().HasKey(c => new
            {
                c.Id,
                c.LogInstance
            });

            //ContactPerson
            builder.Entity<ContactPerson>().HasIndex(m => new { m.Name }).IsUnique();
            builder.Entity<ContactPerson>().Property(m => m.CreateDate).HasDefaultValueSql("getDate()");
            builder.Entity<ContactPerson>().Property(m => m.UpdateDate).HasDefaultValueSql("getDate()");
            builder.Entity<ContactPersonLog>().HasKey(c => new
            {
                c.Id,
                c.LogInstance
            });

        }
    }
}