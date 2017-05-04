using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Budgets
{
    public class BudgetRun : IEntityBase<Guid>
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

    public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public string Budget { get; set; }

    }

    public class BudgetRunLog : IEntityBase<Guid>, ILogEntityBase<Guid>
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

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public string Budget { get; set; }

    }
}
