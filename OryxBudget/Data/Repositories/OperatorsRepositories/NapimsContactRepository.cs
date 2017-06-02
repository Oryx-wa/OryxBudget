using Data.Infrastructure;
using Entities.Napims;
using OryxDomainServices;
using OryxSecurity.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories.OperatorsRepositories
{
    public class NapimsContactRepository : BaseLogBudgetRepository<NapimsContact, NapimsContactLog, Guid>, ILogRepository<NapimsContact, Guid>
    {
        public NapimsContactRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {

        }
    }
}
