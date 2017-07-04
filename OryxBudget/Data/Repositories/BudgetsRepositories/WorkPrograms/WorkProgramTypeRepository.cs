using Data.Infrastructure;
using Entities.Budgets.WorkPrograms;
using OryxDomainServices;
using OryxSecurity.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories.BudgetsRepositories.WorkPrograms
{
    public class WorkProgramTypeRepository : BaseLogBudgetRepository<WorkProgramType, WorkProgramTypeLog, Guid>, ILogRepository<WorkProgramType, Guid>
    {
        public WorkProgramTypeRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {
        }



    }
}
