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
    public class CategoryRepository : BaseLogBudgetRepository<Category, CategoryLog, Guid>, ILogRepository<Category, Guid>
    {
        public CategoryRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {
        }

    }
}