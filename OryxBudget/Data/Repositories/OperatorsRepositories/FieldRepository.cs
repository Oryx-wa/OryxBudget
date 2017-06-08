using Data.Infrastructure;
using Entities.Operators;
using OryxDomainServices;
using OryxSecurity.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories.OperatorsRepositories
{
    public class FieldRepository : BaseLogBudgetRepository<Field, FieldLog, Guid>, ILogRepository<Field, Guid>
    {
        public FieldRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {
        }
    }
}
