using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OryxWebApi.ViewModels.OperatorsViewModels
{
    public class FieldViewModel : BaseViewModel
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public string ConessionId { get; set; }

        public string Dimension { get; set; }

        public long Area { get; set; }

        public long? PlannedVolume { get; set; }

        public decimal? RatePerVolume { get; set; }

        public decimal? TotalCost { get; set; }

        public string Remarks { get; set; }
    }
}
