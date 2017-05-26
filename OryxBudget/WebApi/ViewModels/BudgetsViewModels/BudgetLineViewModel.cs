using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OryxBudgetService.ViewModels.BudgetsViewModels
{
    public class BudgetLineViewModel : BaseViewModel
    {
     
        public string BudgetId { get; set; }
        public int? RowNumber { get; set; }    
        public string Description { get; set; } //ItemName
        
        public decimal SubComBudgetFC { get; set; }

        public decimal SubComBudgetLC { get; set; }

        public decimal SubComBudgetUSD { get; set; }

        public decimal TecComBudgetFC { get; set; }

        public decimal TecComBudgetLC { get; set; }

        public decimal TecComBudgetUSD { get; set; }

        public decimal MalComBudgetFC { get; set; }

        public decimal MalComBudgetLC { get; set; }

        public decimal MalComBudgetUSD { get; set; }

        public decimal FinalBudgetFC { get; set; }

        public decimal FinalBudgetLC { get; set; }

        public decimal FinalBudgetUSD { get; set; }

    }

    public class CombinedLineViewModel
    {
        public BudgetLineViewModel BudgetLine { get; set; }
        public IEnumerable<LineCommentViewModel> LineComments { get; set; }
        

    }
}
