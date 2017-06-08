using Entities.Budgets.WorkPrograms;
using Entities.Common;
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

        [MaxLength(1000)]
        public string Description { get; set; }

        [MaxLength(1000)]
        public string SecondDescription { get; set; }

        [MaxLength(50), Required]
        public string FatherNum { get; set; }

        [MaxLength(100), Required]
        public string Level { get; set; }
        [MaxLength(1)]
        public string  Active { get; set; }

        [MaxLength(50)]
        public string CategoryId { get; set; }
       
        [MaxLength(1)]
        public string Postable { get; set; }

        [MaxLength(20)]
        public string Level1 { get; set; }       
        [MaxLength(30)]
        public string Level2 { get; set; }

        [MaxLength(100)]
        public string CodeCategory { get; set; }

        public WorkProgramTypeEnum Type { get; set; }

        public virtual ICollection<WorkProgramCode> WorkProgramCodes { get; set; }
      
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

        [MaxLength(1000)]
        public string Description { get; set; }

        [MaxLength(1000)]
        public string SecondDescription { get; set; }

        [MaxLength(50), Required]
        public string FatherNum { get; set; }

        [MaxLength(100), Required]
        public string Level { get; set; }


        public string Active { get; set; }

        [MaxLength(50)]
        public string CategoryId { get; set; }
      

        [MaxLength(1)]
        public string Postable { get; set; }

        [MaxLength(20)]
        public string Level1 { get; set; }
        [MaxLength(30)]
        public string Level2 { get; set; }

        [MaxLength(100)]
        public string CodeCategory { get; set; }

        public WorkProgramTypeEnum Type { get; set; }
    }
}
