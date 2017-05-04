using System;
using OryxDomainServices;
using OryxSecurity.Services;
using OryxSecurity.Infrastructure;
using OryxSecurity.Entities;

namespace OryxSecurity.Repositories
{
    public class UserRepository : BaseSecurityRepository<User, Guid>, ILogRepository<User, Guid>
    {
        public UserRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {
        }
        
    }
}
