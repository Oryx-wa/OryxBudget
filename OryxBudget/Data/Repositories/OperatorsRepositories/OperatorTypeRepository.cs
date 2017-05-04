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
   public class OperatorTypeRepository : BaseLogBudgetRepository<OperatorType, OperatorTypeLog, Guid>, ILogRepository<OperatorType, Guid>
    {
        public OperatorTypeRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {
        }

    }
}
