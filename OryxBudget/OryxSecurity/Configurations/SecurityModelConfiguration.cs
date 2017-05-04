using Microsoft.EntityFrameworkCore;
using OryxSecurity.Entities;

namespace OryxSecurity.Configuration
{
    public class SecurityModelConfiguration
    {
        public static void ModelConfiguration(ref ModelBuilder builder)
        {
            //Action
            builder.Entity<Action>().HasAlternateKey(m => m.Name);
            builder.Entity<Action>().Property(m => m.CreateDate).HasDefaultValueSql("getDate()");
            builder.Entity<Action>().Property(m => m.UpdateDate).HasDefaultValueSql("getDate()");

            //Group
            builder.Entity<Group>().Property(m => m.CreateDate).HasDefaultValueSql("getDate()");
            builder.Entity<Group>().Property(m => m.UpdateDate).HasDefaultValueSql("getDate()");

            //SecurityObject
            builder.Entity<SecurityObject>().HasAlternateKey(m => m.Name);
            builder.Entity<SecurityObject>().Property(m => m.CreateDate).HasDefaultValueSql("getDate()");
            builder.Entity<SecurityObject>().Property(m => m.UpdateDate).HasDefaultValueSql("getDate()");

            //User
            builder.Entity<User>().HasAlternateKey(m => m.Name);
            builder.Entity<User>().Property(m => m.CreateDate).HasDefaultValueSql("getDate()");
            builder.Entity<User>().Property(m => m.UpdateDate).HasDefaultValueSql("getDate()");

        }
    }
}
