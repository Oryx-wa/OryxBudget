using Data.Infrastructure;
using Data.Repositories.BudgetsRepositories;
using Entities.Budgets;
using OryxSecurity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OryxBudgetService.BudgetsServices
{
    public class NotificationService : BaseBudgetService<Notification>
    {
        private readonly NotificationRepository _notificationRepo;
        protected IUserResolverService _userResolverService;

        private string CommentDescription = "A comment has been logged on [UAPCode] by [UserFullName]";

        public NotificationService(NotificationRepository notificationRepo, 
            IUserResolverService userResolverService, IBudgetUnitOfWork unitOfWork) 
            : base(notificationRepo, unitOfWork)
        {
            _notificationRepo = notificationRepo;
            _userResolverService = userResolverService;
        }

        public void AddNotification(Notification entity)
        {
            _notificationRepo.Add(entity);
        }
        
        public void AddCommentNotification(string lineCommentId, string budgetCode)
        {
            var commenterUsername = _userResolverService.GetUserName();
            var description = CommentDescription.Replace("[UAPCode]", budgetCode).Replace("[UserFullName]", commenterUsername);
            var entity = new Notification
            {
                Description = description,
                LineCommentId = new Guid(lineCommentId),
                Username = commenterUsername,
                IsRead = false
            };

            this.AddNotification(entity);
        }

        public void UpdateNotification(Guid id)
        {
            var notification = _notificationRepo.Get(id);
            if (notification != null)
            {
                notification.IsRead = true;
                _notificationRepo.Update(notification);
            }
        }

        public IEnumerable<Notification> GetAllNotifications()
        {
            return _notificationRepo.GetAll().OrderBy(n => n.IsRead);
        }

        public IEnumerable<Notification> GetAllUnreadNotifications()
        {
            return _notificationRepo.GetAll().Where(n => !n.IsRead);
        }
    }
}
