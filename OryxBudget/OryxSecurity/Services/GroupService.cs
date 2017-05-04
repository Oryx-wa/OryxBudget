using OryxDomainServices;
using OryxSecurity.Entities;
using OryxSecurity.Infrastructure;
using System;

namespace OryxSecurity.Services
{
    public class GroupService : BaseSecurityService<Group>
    {
        public GroupService(ILogRepository<Group, Guid> repository, ISecurityUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public override void Update(Group entity)
        {

        }
    }
}

