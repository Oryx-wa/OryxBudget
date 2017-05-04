using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OryxWebApi.ViewModels.BudgetsViewModels
{
    public class BudgetLineCategoryViewModel : BaseViewModel
    {
        public string Code { get; set; }

        [Required, MaxLength(100)]
        public string Description { get; set; }

    }
}
