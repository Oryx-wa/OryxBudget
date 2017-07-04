using Entities.Budgets;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Infrastructure;
using OryxSecurity.Services;

namespace Data.Repositories.BudgetsRepositories
{
    public class BudgetLineStatusHistoryRepository : BaseLogBudgetRepository<BudgetLineStatusHistory, StatusHistoryLog, Guid>, ILogRepository<BudgetLineStatusHistory, Guid>
    {
        public BudgetLineStatusHistoryRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {
        }
    }


}
