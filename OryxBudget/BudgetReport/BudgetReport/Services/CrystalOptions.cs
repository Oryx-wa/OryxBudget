using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetReport.Services
{
    public class CrystalOptions
    {
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string reportsFolder { get; set; }
        public string payslipRpt { get; set; }
    }
}
