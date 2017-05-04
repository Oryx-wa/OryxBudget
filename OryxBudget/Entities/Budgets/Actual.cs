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

        public decimal TotalAmount { get; set; }

        [MaxLength(150)]
        public string Remarks { get; set; }

        [MaxLength(50), Required]
        public string BudgetId { get; set; }
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

        [MaxLength(150)]
        public string Remarks { get; set; }

        [MaxLength(50), Required]
        public string BudgetId { get; set; }
    }
}
