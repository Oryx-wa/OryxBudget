using Data.Infrastructure;
using Entities.Budgets;
using OryxDomainServices;
using OryxSecurity.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class BudgetRunRepository : BaseLogBudgetRepository<BudgetRun, BudgetRunLog, Guid>, ILogRepository<BudgetRun, Guid>
    {
        public BudgetRunRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {
        }

    }
}
