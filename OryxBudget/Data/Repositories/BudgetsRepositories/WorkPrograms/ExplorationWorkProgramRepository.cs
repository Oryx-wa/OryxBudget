using Data.Infrastructure;
using Entities.Budgets.WorkPrograms;
using OryxDomainServices;
using OryxSecurity.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories.BudgetsRepositories.WorkPrograms
{
    public class ExplorationWorkProgramRepository : BaseLogBudgetRepository<ExplorationWorkProgram, ExplorationWorkProgramLog, Guid>, ILogRepository<ExplorationWorkProgram, Guid>
    {
        public ExplorationWorkProgramRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {
        }
    }
}
