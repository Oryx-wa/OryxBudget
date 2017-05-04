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
            BudgetLines = new HashSet<BudgetLine>();
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

        public string PeriodId { get; set; }

        public decimal TotalBudgetAmount { get; set; }

        public decimal TotalActualAmount { get; set; }

        public int OperatorId { get; set; }
        
        public virtual Period Period { get; set; }

        public virtual ICollection<BudgetLine> BudgetLines { get; set; }

        public virtual ICollection<Actuals> BudgetActuals { get; set; }

        public virtual BudgetLineCategory BudgetCategory { get; set; }

     
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

        public decimal TotalBudgetAmount { get; set; }

        public decimal TotalActualAmount { get; set; }

        public int OperatorId { get; set; }

        public virtual Period Period { get; set; }

        public virtual ICollection<BudgetLine> BudgetLines { get; set; }

        public virtual ICollection<Actuals> BudgetActuals { get; set; }

       public virtual BudgetLineCategory BudgetCategory { get; set; }

      
    }
    }
