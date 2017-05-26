using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OryxBudgetService.ViewModels.BudgetsViewModels
{
    public class BudgetRunViewModel : BaseViewModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public string Budget { get; set; }
    }
}
