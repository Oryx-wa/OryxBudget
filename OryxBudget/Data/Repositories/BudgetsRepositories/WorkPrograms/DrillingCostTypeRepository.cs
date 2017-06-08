using Data.Infrastructure;
using Entities.Budgets.WorkPrograms;
using OryxDomainServices;
using OryxSecurity.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories.BudgetsRepositories.WorkPrograms
{
    public class DrillingCostTypeRepository : BaseLogBudgetRepository<DrillingCostType, DrillingCostTypeLog, Guid>, ILogRepository<DrillingCostType, Guid>
    {
        public DrillingCostTypeRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {
        }
    }
}
