using OryxDomainServices;
using OryxSecurity.Infrastructure;
using System;

namespace OryxSecurity.Services
{
    public class ActionService : BaseSecurityService<OryxSecurity.Entities.Action>
    {
        public ActionService(ILogRepository<Entities.Action, Guid> repository, ISecurityUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public override void Update(Entities.Action entity)
        {

        }
    }
}

