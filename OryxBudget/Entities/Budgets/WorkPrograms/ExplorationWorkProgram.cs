﻿using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Budgets.WorkPrograms
{
    public class ExplorationWorkProgram : IEntityBase<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        [MaxLength(1)]
        public string Status { get; set; }

        [MaxLength(50)]
        public string UserSign { get; set; }

        public string BudgetCode { get; set; }

        public Guid WorkProgramTypeId { get; set; }

        public Guid BudgetLineId { get; set; }

        public decimal BudgetAmountLC { get; set; }

        public decimal BudgetAmountUSD { get; set; }

        public decimal BudgetAmountFC { get; set; }

        [MaxLength(255)]
        public string Remarks { get; set; }
    }

    public class ExplorationWorkProgramLog : IEntityBase<Guid>, ILogEntityBase<Guid>
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

        public string BudgetCode { get; set; }

        public Guid WorkProgramTypeId { get; set; }

        public Guid BudgetLineId { get; set; }

        public decimal BudgetAmountLC { get; set; }

        public decimal BudgetAmountUSD { get; set; }

        public decimal BudgetAmountFC { get; set; }

        [MaxLength(255)]
        public string Remarks { get; set; }
    }
}