using Entities.Budgets.WorkPrograms;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Budgets
{
    public class Notification : IEntityBase<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }

        [Required, MaxLength(100)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string UrlData { get; set; }

        public Guid LineCommentId { get; set; }

        public string BudgetCode { get; set; }

        public Guid? User { get; set; }

        public string Username { get; set; }

        [MaxLength(50), Required]
        public string OperatorId { get; set; }

        public int WorkProgramId { get; set; }

        public bool IsRead { get; set; }
    }

    public class NotificationLog : IEntityBase<Guid>, ILogEntityBase<Guid>
    {
        public int LogInstance { get; set; }
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }

        [Required, MaxLength(100)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string UrlData { get; set; }

        public Guid LineCommentId { get; set; }

        public string BudgetCode { get; set; }

        public Guid? User { get; set; }

        [MaxLength(100), Required]
        public string Username { get; set; }

        [MaxLength(50), Required]
        public string OperatorId { get; set; }

        public int WorkProgramId { get; set; }

        public bool IsRead { get; set; }
    }
}
