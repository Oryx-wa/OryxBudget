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
        //public string SecondDescription { get; set; }       
        public string FatherNum { get; set; }        
        public int Level { get; set; }
        //public string Level1 { get; set; }
        //public string level1Description { get; set; }
        //public string Level2 { get; set; }
        //public string level2Description { get; set; }
        public Decimal Budget { get; set; }
        public Decimal BudgetLC { get; set; }
        public Decimal BudgetUSD { get; set; }

        public Decimal Actual { get; set; }
        public Decimal ActualLC { get; set; }
        public Decimal ActualUSD { get; set; }

    }

    [NotMapped]
    public class BudgetActuals
    {
        public string Code { get; set; }
        public Decimal Budget { get; set; }
        public Decimal BudgetLC { get; set; }
        public Decimal BudgetUSD { get; set; }

        public Decimal Actual { get; set; }
        public Decimal ActualLC { get; set; }
        public Decimal ActualUSD { get; set; }
    }

    [NotMapped]
    public class OperatorBudget
    {
        
        public Decimal Budget { get; set; }
        public Decimal BudgetLC { get; set; }
        public Decimal BudgetUSD { get; set; }
        public string OperatorId { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }



    }
}
