using Data.Infrastructure;
using Entities.Budgets.WorkPrograms;
using OryxDomainServices;
using OryxSecurity.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories.BudgetsRepositories.WorkPrograms
{
    public class WorkProgramStatusRepository : BaseLogBudgetRepository<WorkProgramStatus, WorkProgramStatusLog, Guid>, ILogRepository<WorkProgramStatus, Guid>
    {
        public WorkProgramStatusRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {

        }

        public override void Add(WorkProgramStatus entity)
        {

            this.updateEntityForAdd(entity.StatusHistory);
            base.Add(entity);
        }
    }
}
