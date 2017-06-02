using Data.Infrastructure;
using Entities.Operators;
using OryxDomainServices;
using OryxSecurity.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories.OperatorsRepositories
{
    public class OilBlockRepository : BaseLogBudgetRepository<OilBlock, OilBlockLog, Guid>, ILogRepository<OilBlock, Guid>
    {
        public OilBlockRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {

        }
    }
}
