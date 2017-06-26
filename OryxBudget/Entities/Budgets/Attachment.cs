using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Budgets
{
    public class Attachment : IEntityBase<Guid>
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

        public Guid? BudgetLineId { get; set; }

        [MaxLength(50)]
        public string Code { get; set; }

        public byte[] FileData { get; set; }

        [Required, MaxLength(50)]
        public string FileName { get; set; }

        [MaxLength(50), Required]
        public string FileType { get; set; }

        public Guid BudgetId { get; set; }

    }


    public class AttachmentLog : IEntityBase<Guid>, ILogEntityBase<Guid>
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }
        public int LogInstance { get; set; }

        public Guid? BudgetLineId { get; set; }

        [MaxLength(50)]
        public string Code { get; set; }

        public byte[] FileData { get; set; }

        [Required, MaxLength(50)]
        public string FileName { get; set; }

        [MaxLength(50), Required]
        public string FileType { get; set; }

        public Guid BudgetId { get; set; }
    }
}
