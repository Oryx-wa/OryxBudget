using Entities.Common;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Napims
{
    public class NapimsContact : IMasterDataBase<Guid>
    {
        [MaxLength(100), Required]
        public string Name { get; set; }

        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public string Status { get; set; }

        [MaxLength(100)]
        public string UserSign { get; set; }

        [MaxLength(100), Required]
        public string LastName { get; set; }

        public Guid UserId { get; set; }

        [Required]
        public Commitee Committee { get; set; }

    }

    public class NapimsContactLog : IMasterDataBase<Guid>, ILogMasterDataBase<Guid>
    {
        public int LogInstance { get; set; }

        [MaxLength(100), Required]
        public string Name { get; set; }

        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public string Status { get; set; }

        [MaxLength(100)]
        public string UserSign { get; set; }

        [MaxLength(100), Required]
        public string LastName { get; set; }

        public Guid UserId { get; set; }

        [Required]
        public Commitee Committee { get; set; }
    }
}
