using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Entities.Budgets;

namespace OryxWebApi.ViewModels.BudgetsViewModels
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
        // public StatusHistoryViewModel StatusHistory { get; set; }
    }

    public class StatusHistoryViewModel
    {
        public StatusHistoryViewModel( BudgetLineStatusHistory statusHistory)
        {
            this.Code = statusHistory.Code;
            this.BudgetId = statusHistory.BudgetId;
            switch (statusHistory.ItemCodeStatus)
            {
                case CommentStatus.New:
                    this.Status = "New";
                    break;
                case CommentStatus.Accepted:
                    this.Status = "Accepted";
                    break;
                case CommentStatus.Parked:
                    this.Status = "Parked";
                    break;
                case CommentStatus.UnderReview:
                    this.Status = "UnderReview";
                    break;
                default:
                    break;
            }
        }
        [Required]
        public string Code { get; set; }
        [Required]
        public string BudgetId { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
