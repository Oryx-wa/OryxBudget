using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Budgets;

namespace OryxBudgetService.CsvMapping
{
    public class BudgetCodeMapping: CsvClassMap<BudgetCode>
    {
        public BudgetCodeMapping()
        {
           
            Map(m => m.Code);
            Map(m => m.Description);
            Map(m => m.SecondDescription);
            Map(m => m.FatherNum);
            Map(m => m.Level);
            Map(m => m.Active);
            //Map(m => m.CategoryId);
            Map(m => m.Postable);
        }

        public string Active { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string SecondDescription { get; set; }
        public string FatherNum { get; set; }
        public string Level { get; set; }
        public string CategoryId { get; set; }
        public string Postable { get; set; }
    }
}
