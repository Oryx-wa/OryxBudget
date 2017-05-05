using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Budgets
{
    public class BudgetCode : IEntityBase<Guid>
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

        [MaxLength(150)]
        public string SecondDescription { get; set; }

        [MaxLength(50), Required]
        public string FatherNum { get; set; }

        [MaxLength(100), Required]
        public string Level { get; set; }

        public bool Active { get; set; }

        [MaxLength(50), Required]
        public string CategoryId { get; set; }

        public Category Category { get; set; }
    }

    public class BudgetCodeLog : IEntityBase<Guid>, ILogEntityBase<Guid>
    {
        public int LogInstance { get; set; }
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

        [MaxLength(150)]
        public string SecondDescription { get; set; }

        [MaxLength(50), Required]
        public string FatherNum { get; set; }

        [MaxLength(100), Required]
        public string Level { get; set; }

        public bool Active { get; set; }

        [MaxLength(50), Required]
        public string CategoryId { get; set; }

        public  Category Category { get; set; }
    }
}
