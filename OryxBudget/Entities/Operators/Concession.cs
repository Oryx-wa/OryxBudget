using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Operators
{
    public class Concession : IEntityBase<Guid>
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

        [MaxLength(50)]
        public string Code { get; set; }

        [MaxLength(255), Required]
        public string Description { get; set; }

        public Guid OperatorId { get; set; }

        public ICollection<Field> Fields { get; set; }
    }

    public class ConcessionLog : IEntityBase<Guid>, ILogEntityBase<Guid>
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

        [MaxLength(50)]
        public string Code { get; set; }

        [MaxLength(255), Required]
        public string Description { get; set; }

        public Guid OperatorId { get; set; }
    }
}
