using Data.Infrastructure;
using Entities.Operators;
using OryxDomainServices;
using OryxSecurity.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories.OperatorsRepositories
{
    public class WellRepository : BaseLogBudgetRepository<Well, WellLog, Guid>, ILogRepository<Well, Guid>
    {
        public WellRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {
        }
    }
}
