﻿using Entities.Common;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Budgets.WorkPrograms
{
    public class WorkProgramType : IEntityBase<Guid>
    {
        [Required, MaxLength(50)]
        public string Code { get; set; }

        [Required, MaxLength(100)]
        public string Description { get; set; }

        [NotMapped]
        public WorkProgramTypeEnum Type { get; set; }

        [MaxLength(50), Column("Type")]
        public string TypeString
        {
            get { return Type.ToString(); }
            private set { Type = value.ParseEnum<WorkProgramTypeEnum>(); }
        }

        [Key]
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [MaxLength(100)]
        public string UserSign { get; set; }
    }

    public class WorkProgramTypeLog : IEntityBase<Guid>, ILogEntityBase<Guid>
    {
        public int LogInstance { get; set; }
        [Key]
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [MaxLength(100)]
        public string UserSign { get; set; }

        [Required, MaxLength(50)]
        public string Code { get; set; }

        [Required, MaxLength(100)]
        public string Description { get; set; }

        [NotMapped]
        public WorkProgramTypeEnum Type { get; set; }

        [MaxLength(50), Column("Type")]
        public string TypeString
        {
            get { return Type.ToString(); }
            private set { Type = value.ParseEnum<WorkProgramTypeEnum>(); }
        }
    }

    public enum WorkProgramTypeEnum
    {
        Exploration = 1,
        MMD = 2,
        Facility = 3,
        Product = 4
    }
}