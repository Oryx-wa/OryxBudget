using Data.Infrastructure;
using Entities.Budgets.WorkPrograms;
using OryxDomainServices;
using OryxSecurity.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories.BudgetsRepositories.WorkPrograms
{
    public class DrillingCostRepository : BaseLogBudgetRepository<DrillingCost, DrillingCostLog, Guid>, ILogRepository<DrillingCost, Guid>
    {
        public DrillingCostRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {
        }
    }
}
