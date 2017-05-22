using System;
using System.Collections.Generic;
using OryxDomainServices;
using System.ComponentModel.DataAnnotations;


namespace Entities.Budgets
{
    public class BudgetLine : IEntityBase<Guid>
    {
        public BudgetLine()
        {
            this.LineComments = new List<LineComment>();
        }

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

        public decimal AmountLC { get; set; }
        public decimal AmountLCInUSD { get; set; }
        public decimal AmountUSD { get; set; }
        public decimal BudgetAmount { get; set; }

        public decimal ActualAmount { get; set; }

       
        public Guid BudgetId { get; set; }

        public string CategoryId { get; set; }

        public ICollection<LineComment> LineComments { get; set; }

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

        public decimal AmountLC { get; set; }
        public decimal AmountUSD { get; set; }
        public decimal AmountLCInUSD { get; set; }
        public decimal BudgetAmount { get; set; }
        public decimal ActualAmount { get; set; }


        public Guid BudgetId { get; set; }

        public string CategoryId { get; set; }

    }
}