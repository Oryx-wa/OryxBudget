using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OryxWebApi.ViewModels.BudgetsViewModels
{
    public class NapimsBudgetViewModel : BaseViewModel
    {
        public string BudgetId { get; set; }

        public int? RowNumber { get; set; }

        public decimal SubComBudgetFC { get; set; }

        public decimal SubComBudgetLC { get; set; }

        public decimal SubComBudgetUSD { get; set; }

        public decimal TecComBudgetFC { get; set; }

        public decimal TecComBudgetLC { get; set; }

        public decimal TecComBudgetUSD { get; set; }

        public decimal MalComBudgetFC { get; set; }

        public decimal MalComBudgetLC { get; set; }

        public decimal MalComBudgetUSD { get; set; }
    }
}
