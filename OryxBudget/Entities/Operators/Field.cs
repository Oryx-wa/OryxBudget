using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Operators
{
    public class Field : IEntityBase<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [MaxLength(50)]
        public string UserSign { get; set; }

        [Required, MaxLength(50)]
        public string Code { get; set; }

        public string Description { get; set; }

        [MaxLength(100)]
        public string ConessionId { get; set; }

        [MaxLength(50)]
        public string Dimension { get; set; }

        public long Area { get; set; }

        public long? PlannedVolume { get; set; }

        public decimal? RatePerVolume { get; set; }

        public decimal? TotalCost { get; set; }

        [MaxLength(255)]
        public string Remarks { get; set; }

        public ICollection<Well> Wells { get; set; }
        
    }

    public class FieldLog : IEntityBase<Guid>, ILogEntityBase<Guid>
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

        [Required, MaxLength(50)]
        public string Code { get; set; }

        public string Description { get; set; }

        [MaxLength(100)]
        public string ConessionId { get; set; }

        [MaxLength(50)]
        public string Dimension { get; set; }

        public long Area { get; set; }

        public long? PlannedVolume { get; set; }

        public decimal? RatePerVolume { get; set; }

        public decimal? TotalCost { get; set; }

        [MaxLength(255)]
        public string Remarks { get; set; }
    }
}
