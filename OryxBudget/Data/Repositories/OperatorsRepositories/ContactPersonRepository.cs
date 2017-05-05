using Data.Infrastructure;
using Entities.Operators;
using OryxDomainServices;
using OryxSecurity.Services;
using System;


namespace Data.Repositories.OperatorsRepositories
{
   public class ContactPersonRepository : BaseLogBudgetRepository<ContactPerson, ContactPersonLog, Guid>, ILogRepository<ContactPerson, Guid>
    {
        public ContactPersonRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {
        }

    }
}
