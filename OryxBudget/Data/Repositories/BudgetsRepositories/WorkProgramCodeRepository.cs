using Data.Infrastructure;
using Entities.Budgets;
using OryxDomainServices;
using OryxSecurity.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories.BudgetsRepositories
{
    public class WorkProgramCodeRepository : BaseLogBudgetRepository<WorkProgramCode, WorkProgramCodeLog, Guid>, ILogRepository<WorkProgramCode, Guid>
    {
        public WorkProgramCodeRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {

        }
    }
}
