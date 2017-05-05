using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OryxWebApi.ViewModels.BudgetsViewModels
{
    public class BudgetCodeViewModel : BaseViewModel
    {
        [MaxLength(20), Required]
        public string Code { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }

        [MaxLength(150)]
        public string SecondDescription { get; set; }

        [MaxLength(50), Required]
        public string FatherNum { get; set; }

        [MaxLength(100), Required]
        public string Level { get; set; }

        public bool Active { get; set; }

        [MaxLength(50), Required]
        public string CategoryId { get; set; }

        
    }
}
