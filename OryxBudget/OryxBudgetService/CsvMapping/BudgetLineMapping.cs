using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Budgets;

namespace OryxBudgetService.CsvMapping
{
    public class BudgetLineMapping : CsvClassMap<BudgetLine>
    {
        public BudgetLineMapping()
        {

            Map(m => m.BudgetId).ConvertUsing(row => Guid.Parse(row.GetField("BudgetId")));
            Map(m => m.Code);
            Map(m => m.Description);            
            Map(m => m.AmountLC);
            Map(m => m.AmountLCInUSD);
            Map(m => m.AmountUSD);
        }

       
    }

    public class BudgetActualMapping : CsvClassMap<Actual>
    {
        public BudgetActualMapping()
        {

            Map(m => m.BudgetId).ConvertUsing(row => Guid.Parse(row.GetField("BudgetId")));
            Map(m => m.Code);
            Map(m => m.Description);
            Map(m => m.AmountLC);
            Map(m => m.AmountLCInUSD);
            Map(m => m.AmountUSD);
            Map(m => m.PeriodStart);
            Map(m => m.PeriodEnd);
            Map(m => m.Remarks);
        }

       
    }


}
