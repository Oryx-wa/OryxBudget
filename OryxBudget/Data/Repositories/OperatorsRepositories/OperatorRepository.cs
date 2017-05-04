using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Operators;
using OryxSecurity.Services;
using OryxDomainServices;

namespace Data.Repositories.OperatorsRepositories
{
   public class OperatorRepository : BaseLogBudgetRepository<Operator, OperatorLog, Guid>, ILogRepository<Operator, Guid>
    {
        public OperatorRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {
        }

    }
}
