using OryxDomainServices;
using OryxSecurity.Entities;
using OryxSecurity.Infrastructure;
using System;

namespace OryxSecurity.Services
{
    public class UserService : BaseSecurityService<User>
    {
        public UserService(ILogRepository<User, Guid> repository, ISecurityUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public override void Update(User entity)
        {

        }
    }
}

