using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Budgets
{   
    [NotMapped]
   public class BudgetCodeView
    {
       
        public string Code { get; set; }       
        public string Description { get; set; }        
        public string SecondDescription { get; set; }       
        public string FatherNum { get; set; }        
        public string Level { get; set; }
        public string Level1 { get; set; }
        public string level1Description { get; set; }
        public string Level2 { get; set; }
        public string level2Description { get; set; }
        public Decimal BudgetAmount { get; set; }
        public Decimal BudgetAmountLC { get; set; }
        public Decimal BudgetAmountUSD { get; set; }

        public Decimal ActualAmount { get; set; }
        public Decimal ActualAmountLC { get; set; }
        public Decimal AcutalAmountUSD { get; set; }

    }
}
