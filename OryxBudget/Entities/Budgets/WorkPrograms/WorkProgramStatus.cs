using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Budgets.WorkPrograms
{
    public class WorkProgramStatus : IEntityBase<Guid>
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

        public Guid BudgetId { get; set; }

        public SignOffStatus ProgramStatus { get; set; }
    }

    public class WorkProgramStatusLog : IEntityBase<Guid>, ILogEntityBase<Guid>
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

        public Guid BudgetId { get; set; }

        public SignOffStatus ProgramStatus { get; set; }
    }

    public enum SignOffStatus
    {
        Approved = 1,
        Rejected = 2
    }
}
