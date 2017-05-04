using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OryxWebApi.ViewModels.BudgetsViewModels
{
    public class BudgetLineViewModel : BaseViewModel
    {
     
        public string BudgetId { get; set; }

        public int? RowNumber { get; set; }

        //public int BudgetCategoryId { get; set; }

      //  public string Code
      //  {
            //get { return BudgetLineCategory.Code + "." + RowNumber; }
      //      get; set;
      //  }

        [Required, MaxLength(100)]
        public string Description { get; set; } //ItemName

        //public string Description { get; set; }

        public decimal BudgetAmount { get; set; }

        public decimal ActualAmount { get; set; }

        //public int? TenantId { get; set; }

       //  public virtual Budget Budget { get; set; }

        //public virtual BudgetLineCategory BudgetLineCategory { get; set; }

      //  public virtual ICollection<LineComment> LineComments { get; set; }
    }

   //  public class CombinedEducationViewModel
   //  {
     //    public IEnumerable<BudgetLineViewModel> EducationInfo { get; set; }
       // public IEnumerable<AccreditationInfoViewModel> AccreditationInfo { get; set; }
       // public IEnumerable<TrainingInfoViewModel> TrainingInfo { get; set; }
        
   // }
}
