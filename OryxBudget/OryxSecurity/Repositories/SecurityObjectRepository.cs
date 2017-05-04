using System;
using OryxDomainServices;
using OryxSecurity.Services;
using OryxSecurity.Infrastructure;
using OryxSecurity.Entities;

namespace OryxSecurity.Repositories
{
    public class SecurityObjectRepository : BaseSecurityRepository<SecurityObject, Guid>, ILogRepository<SecurityObject, Guid>
    {
        public SecurityObjectRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {
        }
        
    }
}
