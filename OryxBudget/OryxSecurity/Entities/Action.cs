using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;


namespace OryxSecurity.Entities
{
    public class Action : IMasterDataBase<Guid>
    {

        [MaxLength(30)]
        public string Code { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string UserSign { get; set; }

        public string Status { get; set; }

        [Key]
        public Guid Id { get; set; }
    }

    public class ActionLog : IEntityBase<Guid>, ILogMasterDataBase<Guid>
    {

        [MaxLength(30)]
        public string Code { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UserSign { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string Status { get; set; }

        public Guid Id { get; set; }
        [Key]
        public int LogInstance { get; set; }
    }
}
