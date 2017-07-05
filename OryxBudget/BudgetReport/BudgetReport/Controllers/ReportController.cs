using System.Linq;
using CrystalDecisions.Shared;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using BudgetReport.Services;

namespace BudgetReport.Controllers
{
    public class ReportController : Controller
    {
        private readonly ReportService _reportService;
        public ReportController(ReportService reportService)
        {
            _reportService = reportService;
        }
        public FileResult Index(string BudgetId)
        {
            return _reportService.GetBudgetReport(BudgetId);
        }
    }
}
