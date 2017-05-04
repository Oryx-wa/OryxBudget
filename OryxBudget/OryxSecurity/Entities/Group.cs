using OryxDomainServices;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace OryxSecurity.Entities
{
    public class Group : IMasterDataBase<Guid>
    {
        public Group()
        {
            this.Users = new List<User>();
        }

        public DateTime CreateDate
        {
            get; set;
        }

        [Key]
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime UpdateDate
        {
            get; set;
        }

        public virtual ICollection<User> Users { get; set; }

        public string UserSign
        {
            get; set;
        }

        public string Status { get; set; }
    }

    public class GroupLog : IEntityBase<Guid>, ILogMasterDataBase<Guid>
    {
        public GroupLog()
        {
            this.Users = new List<User>();
        }

        public DateTime CreateDate
        {
            get; set;
        }
        public DateTime EffectiveDate { get; set; }
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime UpdateDate
        {
            get; set;
        }

        public virtual ICollection<User> Users { get; set; }

        public string UserSign
        {
            get; set;
        }

        public string Status { get; set; }
        [Key]
        public int LogInstance { get; set; }
    }
}
