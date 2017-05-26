using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OryxWebApi.ViewModels.BudgetsViewModels
{
    public class ActualViewModel : BaseViewModel
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
        public string BudgetId { get; set; }
    }
}
