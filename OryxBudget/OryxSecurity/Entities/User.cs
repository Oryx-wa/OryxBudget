using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OryxSecurity.Entities
{
    public class User : IMasterDataBase<Guid>
    {

        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Name
        {
            get; set;
        }
        [Key]
        public Guid Id
        {
            get; set;
        }

        public DateTime CreateDate
        {
            get; set;
        }

        public DateTime UpdateDate
        {
            get; set;
        }

        public string UserSign
        {
            get; set;
        }
        public DateTime EffectiveDate { get; set; }
        public string Status { get; set; }
    }

    public class UserLog : IEntityBase<Guid>, ILogMasterDataBase<Guid>
    {

        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Name
        {
            get; set;
        }
        public Guid Id
        {
            get; set;
        }

        public DateTime CreateDate
        {
            get; set;
        }

        public DateTime UpdateDate
        {
            get; set;
        }

        public string UserSign
        {
            get; set;
        }

        public string Status { get; set; }
        [Key]
        public int LogInstance { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
