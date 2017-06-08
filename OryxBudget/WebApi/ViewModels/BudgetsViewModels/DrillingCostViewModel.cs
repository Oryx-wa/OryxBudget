using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OryxWebApi.ViewModels.BudgetsViewModels
{
    public class DrillingCostViewModel : BaseViewModel
    {
        public string TypeId { get; set; }
        
        public string WellId { get; set; }
        
        public string BudgetCode { get; set; }
        
        public string BudgetLineId { get; set; }

        public decimal BudgetAmountLC { get; set; }

        public decimal BudgetAmountUSD { get; set; }

        public decimal BudgetAmountFC { get; set; }

        public string Remarks { get; set; }
    }
}
