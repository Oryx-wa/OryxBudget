using Data.Infrastructure;
using Data.Repositories.BudgetsRepositories;
using Entities.Budgets;
using Entities.Budgets.WorkPrograms;
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
        private readonly BudgetLineService _budgetLineService;
        private readonly BudgetService _budgetService;
        protected IUserResolverService _userResolverService;

        private string CommentDescription = "A comment has been logged on [UAPCode] by [UserFullName]";

        public NotificationService(NotificationRepository notificationRepo, 
            BudgetLineService budgetLineService, BudgetService budgetService,
            IUserResolverService userResolverService, IBudgetUnitOfWork unitOfWork) 
            : base(notificationRepo, unitOfWork)
        {
            _notificationRepo = notificationRepo;
            _budgetLineService = budgetLineService;
            _budgetService = budgetService;
            _userResolverService = userResolverService;
        }

        public void AddNotification(Notification entity)
        {
            _notificationRepo.Add(entity);
        }
        
        public void AddCommentNotification(string lineCommentId, string budgetCode)
        {
            var line = _budgetLineService.GetByCode(budgetCode);
            var budget = _budgetService.Get(line.BudgetId);

            var dept = _userResolverService.GetDepartment();
            int type = (int)Enum.Parse(typeof(WorkProgramTypeEnum), dept);
            var commenterUsername = _userResolverService.GetUserName();
            var description = CommentDescription.Replace("[UAPCode]", budgetCode).Replace("[UserFullName]", commenterUsername);
            var entity = new Notification
            {
                Description = description,
                LineCommentId = new Guid(lineCommentId),
                Username = commenterUsername,
                BudgetCode = budgetCode,
                OperatorId = budget.OperatorId,
                WorkProgramId = type,
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
            return GetAllNotifications(string.Empty, null).OrderBy(n => n.IsRead);
        }

        public IEnumerable<Notification> GetAllNotifications(string operatorId, int? workProgramId)
        {
            return _notificationRepo.GetAll().Where(n => n.OperatorId == operatorId 
            && n.WorkProgramId == workProgramId).OrderBy(n => n.IsRead);
        }

        public IEnumerable<Notification> GetAllUnreadNotifications(string operatorId, int workProgramId)
        {
            return _notificationRepo.GetAll().Where(n => !n.IsRead && n.OperatorId == operatorId && 
            n.WorkProgramId == workProgramId );
        }
    }
}
