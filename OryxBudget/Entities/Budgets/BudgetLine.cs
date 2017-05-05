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

        [Required, MaxLength(100)]
        public string BudgetId { get; set; }

        public int? RowNumber { get; set; }

        public int CategoryId { get; set; }
        [Required, MaxLength(20)]
        public string Code { get; set; }
        

        [Required, MaxLength(100)]
        public string Description { get; set; } //ItemName

        public decimal BudgetAmount { get; set; }

        public decimal ActualAmount { get; set; }

       
        public Budget Budget { get; set; }

        public Category BudgetLineCategory { get; set; }

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
        [Required, MaxLength(100)]
        public string BudgetId { get; set; }

        public int? RowNumber { get; set; }

        public int CategoryId { get; set; }
        [Required, MaxLength(20)]
        public string Code { get; set; }
        [Required, MaxLength(100)]
        public string Description { get; set; } //ItemName

         public decimal BudgetAmount { get; set; }

        public decimal ActualAmount { get; set; }

       
        public  Budget Budget { get; set; }

        public Category Category { get; set; }

        public  ICollection<LineComment> LineComments { get; set; }
    }
}