using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OryxWebApi.ViewModels.BudgetsViewModels
{
    public class NotificationViewModel
    {
        public string Description { get; set; }

        [MaxLength(100)]
        public string UrlData { get; set; }

        public Guid LineCommentId { get; set; }

        public string BudgetCode { get; set; }

        public Guid? User { get; set; }

        [MaxLength(100), Required]
        public string Username { get; set; }

        public bool IsRead { get; set; }
    }
}
