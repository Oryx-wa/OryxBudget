using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OryxDomainServices
{
    public class MasterDataBase<TId> : IMasterDataBase<TId>
    {
        [Key]
        public TId Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [Required]
        public string UserSign { get; set; }

        public string Status { get; set; }
        
    }
}
