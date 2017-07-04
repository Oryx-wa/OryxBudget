using Entities.Budgets.WorkPrograms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OryxWebApi.ViewModels.BudgetsViewModels
{
    public class WorkProgramStatusViewModel
    {
        //public WorkProgramStatusViewModel(WorkProgramStatus programStatus)
        //{
        //    this.BudgetId = programStatus.BudgetId;
        //    switch(programStatus.ProgramStatus)
        //    {
        //        case SignOffStatus.Approved:
        //            this.Status = "Approved";
        //            break;
        //        case SignOffStatus.Rejected:
        //            this.Status = "Rejected";
        //            break;
        //        default:
        //            break;
        //    }

        //}
        [Required]
        public Guid BudgetId { get; set; }
        [Required]
        public string Status { get; set; }
        public string Department { get; set; }
    }
}
