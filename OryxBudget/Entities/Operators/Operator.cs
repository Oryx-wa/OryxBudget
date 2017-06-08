using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Operators
{
    public class Operator : IMasterDataBase<Guid>
    {
        public Operator()
        {
            this.ContactPersons = new HashSet<ContactPerson>();
        }

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
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }

        [MaxLength(20), Required]
        public string Code { get; set; }

        [MaxLength(50)]
        public string OperatorTypeId { get; set; }
        [MaxLength(250)]
        public string ImageSrc { get; set; }

        public ICollection<ContactPerson> ContactPersons { get; set; }
        public ICollection<Concession> OilBlocks { get; set; }

       // public bool IsJV { get; set; }
       // public bool IsPSC { get; set; }

       

    }

    public class OperatorLog : IMasterDataBase<Guid>, ILogMasterDataBase<Guid>
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

        [MaxLength(20), Required]
        public string Code { get; set; }

        [MaxLength(50)]
        public string OperatorTypeId { get; set; }
        [MaxLength(250)]
        public string ImageSrc { get; set; }

        // public bool IsJV { get; set; }
        // public bool IsPSC { get; set; }




    }
}
