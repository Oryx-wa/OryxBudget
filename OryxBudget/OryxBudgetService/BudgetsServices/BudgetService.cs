using Data.Infrastructure;
using Entities.Budgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repositories;

namespace OryxBudgetService.BudgetsServices
{
    public class BudgetService : BaseBudgetService<Budget>
    {
        private readonly IBaseLogBudgetRepository<Budget, BudgetLog, Guid> _repository;

        public BudgetService(IBaseLogBudgetRepository<Budget, BudgetLog, Guid> repository, IBudgetUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
        }

        public override void Update(Budget entity)
        {
            Budget dbBudget = this.Get(entity.Id);
           


            base.Update(dbBudget);

        }

        public IEnumerable<Budget> GetByPeriodId(string periodId)
        {
            return this.GetAll().Where(info => info.PeriodId == periodId);
        }

       
    }
}
