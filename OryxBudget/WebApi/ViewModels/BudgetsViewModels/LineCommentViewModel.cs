using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OryxWebApi.ViewModels.BudgetsViewModels
{
    public class LineCommentViewModel: BaseViewModel
    {
        public string BudgetId { get; set; }

        public string Comment { get; set; }

        public string Code { get; set; }

        public string CommentStatus  { get; set; }

       // public virtual BudgetLine BudgetLine { get; set; }

    }
}
