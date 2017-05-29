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
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserType { get; set; }
        

       // public virtual BudgetLine BudgetLine { get; set; }

    }
}
