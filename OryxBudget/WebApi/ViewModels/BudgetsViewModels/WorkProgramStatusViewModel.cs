﻿using Entities.Budgets.WorkPrograms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OryxWebApi.ViewModels.BudgetsViewModels
{
    public class WorkProgramStatusViewModel
    {
        public WorkProgramStatusViewModel(WorkProgramStatus programStatus)
        {
            this.Id = programStatus.Id;
            this.BudgetId = programStatus.BudgetId;
            this.Department = programStatus.WorkProgram.ToString();
            this.BudgetStatus = programStatus.BudgetStatus.ToString();           

        }
        public Guid Id { get; set; }
        [Required]
        public Guid BudgetId { get; set; }
        [Required]
        public string BudgetStatus { get; set; }
        public string Department { get; set; }
    }
}