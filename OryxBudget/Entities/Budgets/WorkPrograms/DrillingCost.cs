using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Budgets.WorkPrograms
{
    public class DrillingCost : IEntityBase<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [MaxLength(50)]
        public string UserSign { get; set; }

        [MaxLength(50)]
        public string TypeId { get; set; }

        [MaxLength(50)]
        public string WellId { get; set; }

        [MaxLength(50)]
        public string BudgetCode { get; set; }

        [MaxLength(50)]
        public string BudgetLineId { get; set; }

        public decimal BudgetAmountLC { get; set; }

        public decimal BudgetAmountUSD { get; set; }

        public decimal BudgetAmountFC { get; set; }

        [MaxLength(255)]
        public string Remarks { get; set; }
    }

    public class DrillingCostLog : IEntityBase<Guid>, ILogEntityBase<Guid>
    {
        public int LogInstance { get; set; }
        [Key]
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [MaxLength(50)]
        public string UserSign { get; set; }

        [MaxLength(50)]
        public string TypeId { get; set; }

        [MaxLength(50)]
        public string WellId { get; set; }

        [MaxLength(50)]
        public string BudgetCode { get; set; }

        [MaxLength(50)]
        public string BudgetLineId { get; set; }

        public decimal BudgetAmountLC { get; set; }

        public decimal BudgetAmountUSD { get; set; }

        public decimal BudgetAmountFC { get; set; }

        [MaxLength(255)]
        public string Remarks { get; set; }
    }
}
