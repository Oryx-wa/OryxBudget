using Data.Infrastructure;
using Entities.Budgets;
using OryxDomainServices;
using OryxSecurity.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories.BudgetsRepositories
{
    public class NotificationRepository : BaseLogBudgetRepository<Notification, NotificationLog, Guid>, ILogRepository<Notification, Guid>
    {
        public NotificationRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {

        }
    }
}
