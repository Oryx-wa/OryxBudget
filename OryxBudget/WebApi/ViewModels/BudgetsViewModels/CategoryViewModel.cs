using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OryxBudgetService.ViewModels.BudgetsViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        public string Code { get; set; }

        [Required, MaxLength(100)]
        public string Description { get; set; }

    }
}
