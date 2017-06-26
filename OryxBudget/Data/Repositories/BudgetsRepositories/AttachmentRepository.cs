using Entities.Budgets;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Data.Infrastructure;
using OryxSecurity.Services;

namespace Data.Repositories.BudgetsRepositories
{
    public class AttachmentRepository : BaseLogBudgetRepository<Attachment, AttachmentLog, Guid>, ILogRepository<Attachment, Guid>
    {
        public AttachmentRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {
        }
    }
}
