using OryxDomainServices;
using OryxSecurity.Entities;
using OryxSecurity.Infrastructure;
using System;

namespace OryxSecurity.Services
{
    public class SecurityObjectService : BaseSecurityService<SecurityObject>
    {
        public SecurityObjectService(ILogRepository<SecurityObject, Guid> repository, ISecurityUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public override void Update(SecurityObject entity)
        {

        }
    }
}

