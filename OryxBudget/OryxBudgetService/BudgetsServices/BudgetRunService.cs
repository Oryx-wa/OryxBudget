using Data.Infrastructure;
using Entities.Budgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repositories;
using OryxBudgetService;

namespace OryxBudgetService.BudgetsServices
{
    public class BudgetRunService : BaseBudgetService<BudgetRun>
    {
        private readonly IBaseLogBudgetRepository<BudgetRun, BudgetRunLog, Guid> _repository;

        public BudgetRunService(IBaseLogBudgetRepository<BudgetRun, BudgetRunLog, Guid> repository, IBudgetUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
        }

        public override void Update(BudgetRun entity)
        {
            BudgetRun dbBudgetRun = this.Get(entity.Id);



            base.Update(dbBudgetRun);

        }

        public IEnumerable<BudgetRun> GetByBudgetRunId(string bgtId)
        {
            return this.GetAll().Where(info => info.BudgetId == bgtId);
        }


    }
}
