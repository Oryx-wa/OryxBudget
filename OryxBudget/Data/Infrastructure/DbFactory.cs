using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OryxDomainServices;


namespace Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory 
    {
        OryxBudgetContext dbContext;

        DbContextOptions<OryxBudgetContext> _options;
        IConfigurationRoot Configuration { get; set; }

        public DbFactory(DbContextOptions<OryxBudgetContext> options)
        {
            _options = options;
        }
        public OryxBudgetContext Init()
        {
            //var optionsBuilder = new DbContextOptionsBuilder<OryxMCIContext>();

            //string connString = "Server = localhost; Database = MCI; Trusted_Connection = true; MultipleActiveResultSets = true";
            ////Configuration["Data:DefaultConnection:OryxMCIConnectionString"];
            //optionsBuilder.UseSqlServer(connString);

            return dbContext ?? (dbContext = new OryxBudgetContext(_options));
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
