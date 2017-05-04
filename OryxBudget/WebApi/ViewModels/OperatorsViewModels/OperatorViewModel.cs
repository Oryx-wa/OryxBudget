using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OryxWebApi.ViewModels.OperatorsViewModels
{
    public class OperatorViewModel : BaseViewModel
    {
        public string Code { get; set; }
        public string OperatorType { get; set; }
        public string IsJV { get; set; }
        public string IsPSC { get; set; }
        public string ContactPerson { get; set; }
    }
}
