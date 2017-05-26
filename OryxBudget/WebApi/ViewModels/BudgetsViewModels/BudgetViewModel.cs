using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OryxBudgetService.ViewModels.BudgetsViewModels
{
    public class BudgetViewModel : BaseViewModel
    {

             public string Description { get; set; }

        [MaxLength(300)]
        public string AdditionalStatement { get; set; }

        public string PeriodId { get; set; }

        public decimal TotalBudgetAmount { get; set; }

        public decimal TotalActualAmount { get; set; }

        public int OperatorId { get; set; }

       //  public virtual Period Period { get; set; }

        // public virtual ICollection<BudgetLine> BudgetLines { get; set; }

        //public virtual ICollection<BudgetActual> BudgetActuals { get; set; }

        //public virtual BudgetCategory BudgetCategory { get; set; }

       // public virtual Tenant Operator { get; set; }

    }
}
