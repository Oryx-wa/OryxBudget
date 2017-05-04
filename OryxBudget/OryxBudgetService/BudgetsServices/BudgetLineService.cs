using Data.Infrastructure;
using Data.Repositories;
using Entities.Budgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OryxBudgetService.BudgetsServices
{
    public class BudgetLineService : BaseBudgetService<BudgetLine>
    {
        private readonly IBaseLogBudgetRepository<BudgetLine, BudgetLineLog, Guid> _repository;

        public BudgetLineService(IBaseLogBudgetRepository<BudgetLine, BudgetLineLog, Guid> repository, IBudgetUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
        }

        public override void Update(BudgetLine entity)
        {
            BudgetLine dbBudgetLine = this.Get(entity.Id);
           


            base.Update(dbBudgetLine);

        }

        public IEnumerable<BudgetLine> GetByBudgetId(string bgtId)
        {
            return this.GetAll().Where(info => info.BudgetId == bgtId);
        }

        
    }
}
