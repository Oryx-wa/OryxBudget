using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Budgets;
using OryxSecurity.Services;
using OryxDomainServices;

namespace Data.Repositories.BudgetsRepositories
{
    public class BudgetRepository : BaseLogBudgetRepository<Budget, BudgetLog, Guid>, ILogRepository<Budget, Guid>
    {
        public BudgetRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {
        }

    }
}