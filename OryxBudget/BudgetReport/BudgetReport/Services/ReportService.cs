using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetReport.Services
{
    public class ReportService
    {
        private CrystalOptions _crystalOptions;
        readonly ILogger<ReportService> _log;

        public ReportService(CrystalOptions crystalOptions, ILogger<ReportService> log)
        {
            _crystalOptions = crystalOptions;
            _log = log;
        }

        public FileStreamResult GetBudgetReport(string budgetId)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(_crystalOptions.payslipRpt);

            // Report connection
            setConnectionProperties(rd);

            rd.SetParameterValue("BudgetId", budgetId);

            Stream stream = rd.ExportToStream(ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return new FileStreamResult(stream, "application/pdf");
        }

        private void setConnectionProperties(ReportDocument rd)
        {
            ConnectionInfo connInfo = new ConnectionInfo()
            {
                ServerName = this._crystalOptions.ServerName,
                DatabaseName = this._crystalOptions.DatabaseName,
                UserID = this._crystalOptions.UserId,
                Password = this._crystalOptions.Password
            };

            TableLogOnInfo tableLogOnInfo = new TableLogOnInfo()
            {
                ConnectionInfo = connInfo
            };

            foreach (Table table in rd.Database.Tables)
            {
                table.ApplyLogOnInfo(tableLogOnInfo);
                table.LogOnInfo.ConnectionInfo.ServerName = connInfo.ServerName;
                table.LogOnInfo.ConnectionInfo.DatabaseName = connInfo.DatabaseName;
                table.LogOnInfo.ConnectionInfo.UserID = connInfo.UserID;
                table.LogOnInfo.ConnectionInfo.Password = connInfo.Password;
            }

            foreach (ReportDocument rd1 in rd.Subreports)
            {
                foreach (Table table in rd1.Database.Tables)
                {
                    table.ApplyLogOnInfo(tableLogOnInfo);
                    table.LogOnInfo.ConnectionInfo.ServerName = connInfo.ServerName;
                    table.LogOnInfo.ConnectionInfo.DatabaseName = connInfo.DatabaseName;
                    table.LogOnInfo.ConnectionInfo.UserID = connInfo.UserID;
                    table.LogOnInfo.ConnectionInfo.Password = connInfo.Password;
                }
            }
        }
    }
}
