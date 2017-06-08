using Entities.Budgets;
using Entities.Common;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Operators
{
   public class ContactPerson : IMasterDataBase<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(50)]
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }

        [Required] [MaxLength(50)]
        public string UserSign { get; set; }
        
        [MaxLength(100), Required]
        public string LastName { get; set; }

        [MaxLength(50), Required]
        public Guid OperatorId { get; set; }

        public BudgetStatus Commitee { get; set; }
    }

    public class ContactPersonLog : IMasterDataBase<Guid>, ILogMasterDataBase<Guid>
    {
        public int LogInstance { get; set; }
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(50)]
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }

        [MaxLength(100), Required]
        public string LastName { get; set; }

        [MaxLength(50), Required]
        public string OperatorId { get; set; }

        public BudgetStatus Commitee { get; set; }
    }
}
