using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OryxWebApi.ViewModels.OperatorsViewModels
{
    public class WellViewModel : BaseViewModel
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string WellTypeId { get; set; }
        public string FieldId { get; set; }
        public string Location { get; set; }
        
        public string Terrain { get; set; }

        public DateTime? SpudDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal? RigRate { get; set; }

        public decimal? SupportService { get; set; }

        public decimal? TotalCost { get; set; }
    }
}
