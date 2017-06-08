using Data.Infrastructure;
using Entities.Operators;
using OryxDomainServices;
using OryxSecurity.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories.OperatorsRepositories
{
    public class OilBlockRepository : BaseLogBudgetRepository<Concession, ConcessionLog, Guid>, ILogRepository<Concession, Guid>
    {
        public OilBlockRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {

        }
    }
}
