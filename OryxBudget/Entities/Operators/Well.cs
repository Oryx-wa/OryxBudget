using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Operators
{
    public class Well : IEntityBase<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [MaxLength(50)]
        public string UserSign { get; set; }

        [MaxLength(50), Required]
        public string Code { get; set; }

        [MaxLength(250), Required]
        public string Description { get; set; }

        [MaxLength(50)]
        public string WellTypeId { get; set; }

        [MaxLength(50)]
        public string FieldId { get; set; }

        [MaxLength(150)]
        public string Location { get; set; }

        [MaxLength(100)]
        public string Terrain { get; set; }

        public DateTime? SpudDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal? RigRate { get; set; }

        public decimal? SupportService { get; set; }

        public decimal? TotalCost { get; set; }
    }

    public class WellLog : IEntityBase<Guid>, ILogEntityBase<Guid>
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

        [MaxLength(50), Required]
        public string Code { get; set; }

        [MaxLength(250), Required]
        public string Description { get; set; }

        [MaxLength(50)]
        public string WellTypeId { get; set; }

        [MaxLength(50)]
        public string FieldId { get; set; }

        [MaxLength(150)]
        public string Location { get; set; }

        [MaxLength(100)]
        public string Terrain { get; set; }

        public DateTime? SpudDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal? RigRate { get; set; }

        public decimal? SupportService { get; set; }

        public decimal? TotalCost { get; set; }
    }
}
