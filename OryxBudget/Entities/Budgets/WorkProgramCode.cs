using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Budgets
{
    public class WorkProgramCode : IEntityBase<Guid>
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

        public string Code { get; set; }

        public string Description { get; set; }

        public string BudgetCode { get; set; }

       
    }

    public class WorkProgramCodeLog : IEntityBase<Guid>, ILogEntityBase<Guid>
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

        public string Code { get; set; }

        public string Description { get; set; }

        public string BudgetCode { get; set; }

       
    }
}
