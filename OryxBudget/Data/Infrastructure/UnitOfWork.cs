using OryxDomainServices;

namespace Data.Infrastructure
{
    public class BudgetUnitOfWork : IBudgetUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private OryxBudgetContext dbContext;

        public BudgetUnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public OryxBudgetContext DbContext
        {

            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.Commit();
        }
    }

    public interface IBudgetUnitOfWork : IUnitOfWork
    {

    }
}

