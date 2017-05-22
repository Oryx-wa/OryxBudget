using System;
using System.Collections.Generic;
using OryxDomainServices;
using System.ComponentModel.DataAnnotations;


namespace Entities.Budgets
{
    public class Budget  : IEntityBase<Guid>
    {
        public Budget()
        {
            BudgetLines = new List<BudgetLine>();
            Actuals = new List<Actual>();
            LineComments = new List<LineComment>();
        }

        public string BudgetLineCategoryId { get; set; }
        [Key]
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }

        [Required,MaxLength(100)]
        public string Description { get; set; }

        [MaxLength(300)]
        public string AdditionalStatement { get; set; }

        [MaxLength(50)]
        public string PeriodId { get; set; }

        public decimal OpBudgetFC { get; set; }
        public decimal OpBudgetLC { get; set; }
        public decimal OpBudgetUSD { get; set; }
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
        
        public decimal OpActualFC { get; set; }
        public decimal OpActualLC { get; set; }
        public decimal OpActualUSD { get; set; }
        public decimal SubComActualFC { get; set; }
        public decimal SubComActualLC { get; set; }
        public decimal SubComActualUSD { get; set; }
        public decimal TecComActualFC { get; set; }
        public decimal TecComActualLC { get; set; }
        public decimal TecComActualUSD { get; set; }
        public decimal MalComActualFC { get; set; }
        public decimal MalComActualLC { get; set; }
        public decimal MalComActualUSD { get; set; }
        public decimal FinalActualFC { get; set; }
        public decimal FinalActualLC { get; set; }
        public decimal FinalActualUSD { get; set; }


        [Required]
        public BudgetStatus BudgetStatus { get; set; }
        [Required]
        public BudgetStatus ActualStatus { get; set; }

        [MaxLength(50), Required]
        public string OperatorId { get; set; }

        public ICollection<BudgetLine> BudgetLines { get; set; }
        public ICollection<Actual> Actuals { get; set; }
        public ICollection<LineComment> LineComments { get; set; }

        public  string CategoryId { get; set; }

     
    }
    public class BudgetLog : IEntityBase<Guid>, ILogEntityBase<Guid>
    {
        public int LogInstance {get;set;}
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

        [MaxLength(300)]
        public string AdditionalStatement { get; set; }

        public string PeriodId { get; set; }

        public decimal OpBudgetFC { get; set; }
        public decimal OpBudgetLC { get; set; }
        public decimal OpBudgetUSD { get; set; }
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

        public decimal OpActualFC { get; set; }
        public decimal OpActualLC { get; set; }
        public decimal OpActualUSD { get; set; }
        public decimal SubComActualFC { get; set; }
        public decimal SubComActualLC { get; set; }
        public decimal SubComActualUSD { get; set; }
        public decimal TecComActualFC { get; set; }
        public decimal TecComActualLC { get; set; }
        public decimal TecComActualUSD { get; set; }
        public decimal MalComActualFC { get; set; }
        public decimal MalComActualLC { get; set; }
        public decimal MalComActualUSD { get; set; }
        public decimal FinalActualFC { get; set; }
        public decimal FinalActualLC { get; set; }
        public decimal FinalActualUSD { get; set; }


        [Required]
        public BudgetStatus BudgetStatus { get; set; }
        [Required]
        public BudgetStatus ActualStatus { get; set; }

        [MaxLength(50), Required]
        public string OperatorId { get; set; }

        public ICollection<BudgetLine> BudgetLines { get; set; }

        public string CategoryId { get; set; }

    }

   
}
