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

            
            Map(m => m.Code).Index(0);
            Map(m => m.Description).Index(1);            
            Map(m => m.OpBudgetLC).Index(2);
            Map(m => m.OpBudgetLCInUSD).Index(4);
            Map(m => m.OpBudgetUSD).Index(3);
        }

       
    }

    public class BudgetActualMapping : CsvClassMap<Actual>
    {
        public BudgetActualMapping()
        {

            
            Map(m => m.Code).Index(0);
            Map(m => m.Description).Index(1);
            Map(m => m.OpActualLC).Index(2);
            Map(m => m.OpActualLCInUSD).Index(4);
            Map(m => m.OpActualUSD).Index(3);
            Map(m => m.PeriodStart).ConvertUsing(row => DateTime.Parse(row.GetField("PeriodStart"), new CultureInfo("en-GB"))); 
            Map(m => m.PeriodEnd).ConvertUsing(row => DateTime.Parse(row.GetField("PeriodEnd"), new CultureInfo("en-GB")));
            Map(m => m.Remarks);
        }

       
    }


}
