using System;
using System.Collections.Generic;
using OryxDomainServices;
using System.ComponentModel.DataAnnotations;


namespace Entities.Budgets
{
    public class BudgetLine : IEntityBase<Guid>
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

        public int? RowNumber { get; set; }

        [Required, MaxLength(20)]
        public string Code { get; set; }

        [Required, MaxLength(100)]
        public string Description { get; set; } //ItemName

        public decimal OpBudgetLC { get; set; }
        public decimal OpBudgetLCInUSD { get; set; }
        public decimal OpBudgetUSD { get; set; }
        public decimal OpBudgetFC { get; set; }

        //public decimal ActualAmount { get; set; }

        public decimal SubComBudgetFC { get; set; }
        public decimal SubComBudgetLC { get; set; }
        public decimal SubComBudgetUSD { get; set; }
        public decimal TecComBudgetFC { get; set; }
        public decimal TecComBudgetLC { get; set; }
        public decimal TecComBudgetUSD { get; set; }
        public decimal MalComBudgetFC { get; set; }
        public decimal MalComBudgetLC { get; set; }
        public decimal MalComBudgetUSD { get; set; }
        public decimal FinalBudgetFC { get; set; }
        public decimal FinalBudgetLC { get; set; }
        public decimal FinalBudgetUSD { get; set; }

        [Required]
        public BudgetStatus LineStatus { get; set; }

        [Required]
        public CommentStatus ApprovalStatus { get; set; }

        public Guid BudgetId { get; set; }

        public string CategoryId { get; set; }



    }

    public class BudgetLineLog : IEntityBase<Guid>, ILogEntityBase<Guid>
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


        public int? RowNumber { get; set; }

        [Required, MaxLength(20)]
        public string Code { get; set; }

        [Required, MaxLength(100)]
        public string Description { get; set; } //ItemName

        public decimal OpBudgetLC { get; set; }
        public decimal OpBudgetUSD { get; set; }
        public decimal OpBudgetLCInUSD { get; set; }
        public decimal OpBudgetFC { get; set; }
        // public decimal ActualAmount { get; set; }


        public decimal SubComBudgetFC { get; set; }
        public decimal SubComBudgetLC { get; set; }
        public decimal SubComBudgetUSD { get; set; }
        public decimal TecComBudgetFC { get; set; }
        public decimal TecComBudgetLC { get; set; }
        public decimal TecComBudgetUSD { get; set; }
        public decimal MalComBudgetFC { get; set; }
        public decimal MalComBudgetLC { get; set; }
        public decimal MalComBudgetUSD { get; set; }
        public decimal FinalBudgetFC { get; set; }
        public decimal FinalBudgetLC { get; set; }
        public decimal FinalBudgetUSD { get; set; }

        [Required]
        public BudgetStatus LineStatus { get; set; }
        [Required]
        public CommentStatus ApprovalStatus { get; set; }

        public Guid BudgetId { get; set; }

        public string CategoryId { get; set; }

    }
}