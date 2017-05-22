using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Budgets;
using System.Globalization;

namespace OryxBudgetService.CsvMapping
{
    public class BudgetLineMapping : CsvClassMap<BudgetLine>
    {
        public BudgetLineMapping()
        {

            
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

            
            Map(m => m.Code);
            Map(m => m.Description);
            Map(m => m.AmountLC);
            Map(m => m.AmountLCInUSD);
            Map(m => m.AmountUSD);
            Map(m => m.PeriodStart).ConvertUsing(row => DateTime.Parse(row.GetField("PeriodStart"), new CultureInfo("en-GB"))); 
            Map(m => m.PeriodEnd).ConvertUsing(row => DateTime.Parse(row.GetField("PeriodEnd"), new CultureInfo("en-GB")));
            Map(m => m.Remarks);
        }

       
    }


}
