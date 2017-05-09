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
   public class ActualService : BaseBudgetService<Actual>
    {
        private readonly IBaseLogBudgetRepository<Actual, ActualLog, Guid> _repository;

        public ActualService(IBaseLogBudgetRepository<Actual, ActualLog, Guid> repository, IBudgetUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
        }

        public override void Update(Actual entity)
        {
            Actual dbActuals = this.Get(entity.Id);



            base.Update(dbActuals);

        }

        public IEnumerable<Actual> GetByActualsId(string bgtId)
        {
            return this.GetAll().Where(info => info.BudgetId.ToString() == bgtId);
        }


    }
}
