using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OryxSecurity.Entities
{
    public class SecurityObject : IMasterDataBase<Guid>
    {
        public SecurityObject() {
            this.Actions = new List<Action>();

        }

        public int ObjectId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public virtual ICollection<Action> Actions { get; private set; }

        [Key]
        public Guid Id { get; set; }
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

        public DateTime CreateDate
        {
            get; set;
        }

        public string Status { get; set; }
    }

    public class SecurityObjectLog : IEntityBase<Guid>, ILogMasterDataBase<Guid>
    {
        public SecurityObjectLog()
        {
            this.Actions = new List<Action>();

        }

        public int ObjectId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public virtual ICollection<Action> Actions { get; private set; }

        public Guid Id { get; set; }

        public DateTime UpdateDate
        {
            get; set;
        }

        public virtual ICollection<User> Users { get; set; }

        public string UserSign
        {
            get; set;
        }
        public DateTime EffectiveDate { get; set; }
        public DateTime CreateDate
        {
            get; set;
        }

        public string Status { get; set; }
        [Key]
        public int LogInstance { get; set; }
    }
}
