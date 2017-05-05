using Data.Infrastructure;
using Entities.Budgets;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.Text;
using OryxSecurity.Services;
using Data.Repositories;

namespace Data.Repositories.BudgetsRepositories
{
    public class BudgetLineRepository : BaseLogBudgetRepository<BudgetLine, BudgetLineLog, Guid>, ILogRepository<BudgetLine, Guid>
    {
        public BudgetLineRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {
        }

    }
}