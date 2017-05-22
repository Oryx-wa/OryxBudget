using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Budgets
{
   public class Actual : IEntityBase<Guid>
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
       
        [MaxLength(20), Required]
        public string Code { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }

        public decimal OpActualFC { get; set; }
        public decimal OpActualLC { get; set; }
        public decimal OpActualLCInUSD { get; set; }
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

        public Guid BudgetId { get; set; }

        [Required]
        public BudgetStatus LineStatus { get; set; }

        [MaxLength(150)]
        public string Remarks { get; set; }       

        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }

        //[MaxLength(50), Required]
        public string PeriodId { get; set; }

    }
    public class ActualLog : IEntityBase<Guid>, ILogEntityBase<Guid>
    {
        public int LogInstance {get; set;}
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }

        [MaxLength(20), Required]
        public string Code { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal AmountLC { get; set; }
        public decimal AmountLCInUSD { get; set; }
        public decimal AmountUSD { get; set; }

        [MaxLength(150)]
        public string Remarks { get; set; }

        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public Guid BudgetId { get; set; }

        //[MaxLength(50), Required]
       public string PeriodId { get; set; }
    }
}
