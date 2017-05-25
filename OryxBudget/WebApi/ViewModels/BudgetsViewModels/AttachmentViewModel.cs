using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OryxWebApi.ViewModels.BudgetsViewModels
{
    public class AttachmentViewModel : BaseViewModel
    {
        public Guid? BudgetLineId { get; set; }
        
        public string Code { get; set; }

        public byte[] FileData { get; set; }
        
        public string FileName { get; set; }
        
        public string FileType { get; set; }

        public Guid BudgetId { get; set; }
    }
}
