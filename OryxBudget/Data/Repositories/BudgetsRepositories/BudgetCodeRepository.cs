using Data.Infrastructure;
using Entities.Budgets;
using OryxDomainServices;
using OryxSecurity.Services;
using System;


namespace Data.Repositories.BudgetsRepositories
{
   public class BudgetCodeRepository : BaseLogBudgetRepository<BudgetCode, BudgetCodeLog, Guid>, ILogRepository<BudgetCode, Guid>
    {
        public BudgetCodeRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {
        }

    }
}
