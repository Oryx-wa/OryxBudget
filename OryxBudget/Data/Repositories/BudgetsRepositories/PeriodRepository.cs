using Data.Infrastructure;
using Entities.Budgets;
using OryxDomainServices;
using OryxSecurity.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories.BudgetsRepositories
{
    public class PeriodRepository : BaseLogBudgetRepository<Period, PeriodLog, Guid>, ILogRepository<Period, Guid>
    {
        public PeriodRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {
        }

    }
}
