using Entities.Budgets.WorkPrograms;
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
        public string Level { get; set; }       
        public Decimal OpBudgetFC { get; set; }
        public Decimal OpBudgetLC { get; set; }
        public Decimal OpBudgetUSD { get; set; }
        public decimal SubComBudgetFC { get; set; }
        public decimal SubComBudgetLC { get; set; }
        public decimal SubComBudgetUSD { get; set; }
        public decimal TecComBudgetFC { get; set; }
        public decimal TecComBudgetLC { get; set; }
        public decimal TecComBudgetUSD { get; set; }
        public decimal MalComBudgetFC { get; set; }
        public decimal MalComBudgetLC { get; set; }
        public decimal MalComBudgetUSD { get; set; }
        public decimal FinalBudgetFC { get; set; }
        public decimal FinalBudgetLC { get; set; }
        public decimal FinalBudgetUSD { get; set; }

        
        public Guid BudgetId { get; set; }
        public BudgetStatus BudgetStatus { get; set; }
        public WorkProgramTypeEnum Type { get; set; }
        public ApprovalStatus LineStatus { get; set; }




    }

    [NotMapped]
    public class BudgetActuals
    {
        public string Code { get; set; }
        public string Description { get; set; }
        //public string SecondDescription { get; set; }       
        public string FatherNum { get; set; }
        public string Level { get; set; }
        public Decimal FinalBudgetFC { get; set; }
        public Decimal FinalBudgetLC { get; set; }
        public Decimal FinalBudgetUSD { get; set; }

        public Decimal OpActualFC { get; set; }
        public Decimal OpActualLC { get; set; }
        public Decimal OpActualUSD { get; set; }
        public decimal OpActualLCInUSD { get; set; }

        public Guid BudgetId { get; set; }
        public BudgetStatus BudgetStatus { get; set; }
        public WorkProgramTypeEnum Type { get; set; }

    }

    [NotMapped]
    public class OperatorBudget
    {
        
        public Decimal OpBudgetFC { get; set; }
        public Decimal OpBudgetLC { get; set; }
        public Decimal OpBudgetUSD { get; set; }
        public string OperatorId { get; set; }
        public string OperatorName { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
        public decimal SubComBudgetFC { get; set; }
        public decimal SubComBudgetLC { get; set; }
        public decimal SubComBudgetUSD { get; set; }
        public decimal TecComBudgetFC { get; set; }
        public decimal TecComBudgetLC { get; set; }
        public decimal TecComBudgetUSD { get; set; }
        public decimal MalComBudgetFC { get; set; }
        public decimal MalComBudgetLC { get; set; }
        public decimal MalComBudgetUSD { get; set; }
        public decimal FinalBudgetFC { get; set; }
        public decimal FinalBudgetLC { get; set; }
        public decimal FinalBudgetUSD { get; set; }



    }
}
