using System;
using OryxDomainServices;
using OryxSecurity.Services;
using OryxSecurity.Infrastructure;
using OryxSecurity.Entities;

namespace OryxSecurity.Repositories
{
    public class GroupRepository : BaseSecurityRepository<Group, Guid>, ILogRepository<Group, Guid>
    {
        public GroupRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {
        }
       
    }
}
