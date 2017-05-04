using Data.Infrastructure;
using Entities.Budgets;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.Text;
using OryxSecurity.Services;
using Data.Repositories;

namespace OryxHR.Data.Repositories.BudgetsRepositories
{
    public class BudgetLineCategoryRepository : BaseLogBudgetRepository<BudgetLineCategory, BudgetLineCategoryLog, Guid>, ILogRepository<BudgetLineCategory, Guid>
    {
        public BudgetLineCategoryRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {
        }

    }
}