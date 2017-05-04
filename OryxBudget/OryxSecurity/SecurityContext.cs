using Microsoft.EntityFrameworkCore;
using OryxSecurity.Entities;
using OryxSecurity.Configuration;

namespace OryxSecurity
{
    public class SecurityContext : DbContext
    {
        public SecurityContext(DbContextOptions<SecurityContext> options)
        : base(options)
        {
            // Database.EnsureCreated();
        }

        #region EntitySets
        public DbSet<Action> Actions { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<SecurityObject> SecurityObjects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ActionLog> ActionLogs { get; set; }
        public DbSet<GroupLog> GroupLogs { get; set; }
        public DbSet<SecurityObjectLog> SecurityObjectLogs { get; set; }
        public DbSet<UserLog> UserLogs { get; set; }

        #endregion

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            SecurityModelConfiguration.ModelConfiguration(ref builder);

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
