using System;
using OryxDomainServices;
using OryxSecurity.Services;
using OryxSecurity.Infrastructure;

namespace OryxSecurity.Repositories
{
    public class ActionRepository : BaseSecurityRepository<OryxSecurity.Entities.Action, Guid>, ILogRepository<OryxSecurity.Entities.Action, Guid>
    {
        public ActionRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {
        }
       
    }
}
