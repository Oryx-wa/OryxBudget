using Data.Infrastructure;
using Data.Repositories;
using Entities.Budgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OryxBudgetService.BudgetsServices
{
   public class BudgetCodeService : BaseBudgetService<BudgetCode>
    {
        private readonly IBaseLogBudgetRepository<BudgetCode, BudgetCodeLog, Guid> _repository;

        public BudgetCodeService(IBaseLogBudgetRepository<BudgetCode, BudgetCodeLog, Guid> repository, IBudgetUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
        }

        public override void Update(BudgetCode entity)
        {
            BudgetCode dbBudgetCodes = this.Get(entity.Id);



            base.Update(dbBudgetCodes);

        }

        public IEnumerable<BudgetCode> GetByBudgetCodesId(string bgtCode)
        {
            return this.GetAll().Where(info => info.Code == bgtCode);
        }


    }
}
