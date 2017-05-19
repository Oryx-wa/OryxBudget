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

        public decimal TotalBudgetAmount { get; set; }
        public decimal TotalAmountLC { get; set; }
        public decimal TotalAmountUSD { get; set; }

        public decimal? SubComTotalBudgetAmountLC { get; set; }

        public decimal? TecComTotalBudgetAmountLC { get; set; }

        public decimal? UpComTotalBudgetAmountLC { get; set; }

        public decimal? SubComTotalBudgetAmountUSD { get; set; }

        public decimal? TecComTotalBudgetAmountUSD { get; set; }

        public decimal? UpComTotalBudgetAmountUSD { get; set; }

        public decimal? FinalTotalBudgetAmountLC { get; set; }

        public decimal? FinalTotalBudgetAmountUSD { get; set; }

        public decimal ActualAmount { get; set; }
        public decimal ActualAmountLC { get; set; }
        public decimal ActualAmountUSD { get; set; }

        [MaxLength(50), Required]
        public string OperatorId { get; set; }

        public  ICollection<BudgetLine> BudgetLines { get; set; }
        public ICollection<Actual> Actuals { get; set; }


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

        public decimal TotalAmount { get; set; }
        public decimal TotalAmountLC { get; set; }
        public decimal TotalAmountUSD { get; set; }
        public decimal ActualBudgetAmount { get; set; }
        public decimal ActualAmountLC { get; set; }
        public decimal ActualAmountUSD { get; set; }

        public decimal? SubComTotalBudgetAmountLC { get; set; }

        public decimal? TecComTotalBudgetAmountLC { get; set; }

        public decimal? UpComTotalBudgetAmountLC { get; set; }

        public decimal? SubComTotalBudgetAmountUSD { get; set; }

        public decimal? TecComTotalBudgetAmountUSD { get; set; }

        public decimal? UpComTotalBudgetAmountUSD { get; set; }

        public decimal? FinalTotalBudgetAmountLC { get; set; }

        public decimal? FinalTotalBudgetAmountUSD { get; set; }

        [MaxLength(50), Required]
        public string OperatorId { get; set; }

        public ICollection<BudgetLine> BudgetLines { get; set; }

        public string CategoryId { get; set; }



    }
}
