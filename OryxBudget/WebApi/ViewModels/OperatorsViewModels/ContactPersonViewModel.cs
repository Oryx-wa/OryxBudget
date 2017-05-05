using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OryxWebApi.ViewModels.OperatorsViewModels
{
    public class ContactPersonViewModel : BaseViewModel
    {
      
        

        [MaxLength(100), Required]
        public string LastName { get; set; }

        [MaxLength(50), Required]
        public string OperatorId { get; set; }

    }
}
