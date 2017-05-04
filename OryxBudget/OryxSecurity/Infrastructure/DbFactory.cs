using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OryxDomainServices;


namespace OryxSecurity.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory 
    {
        SecurityContext dbContext;

        DbContextOptions<SecurityContext> _options;
        IConfigurationRoot Configuration { get; set; }

        public DbFactory(DbContextOptions<SecurityContext> options)
        {
            _options = options;
        }
        public SecurityContext Init()
        {
            //var optionsBuilder = new DbContextOptionsBuilder<OryxMCIContext>();

            //string connString = "Server = localhost; Database = MCI; Trusted_Connection = true; MultipleActiveResultSets = true";
            ////Configuration["Data:DefaultConnection:OryxMCIConnectionString"];
            //optionsBuilder.UseSqlServer(connString);

            return dbContext ?? (dbContext = new SecurityContext(_options));
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
