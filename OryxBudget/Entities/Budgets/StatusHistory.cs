using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Budgets
{
    public class StatusHistory: IEntityBase<Guid>
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
        public BudgetStatus ItemStatus { get; set; }

    }

    public class StatusHistoryLog : IEntityBase<Guid>, ILogEntityBase<Guid>
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
        public BudgetStatus ItemStatus { get; set; }

    }

    public class BudgetLineStatusHistory: StatusHistory
    {

    }

    public class ActualStatusHistory: StatusHistory
    {

    }

    public class BudgetStatusHistory: StatusHistory
    {

    }
}
