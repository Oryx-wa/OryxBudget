using Data.Infrastructure;
using Entities.Budgets;
using OryxDomainServices;
using OryxSecurity.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
   public  class ActualsRepository : BaseLogBudgetRepository<Actual, ActualLog, Guid>, ILogRepository<Actual, Guid>
    {
        public ActualsRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {
        }

    }
}
