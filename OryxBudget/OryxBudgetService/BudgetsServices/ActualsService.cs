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
   public class ActualsService : BaseBudgetService<Actuals>
    {
        private readonly IBaseLogBudgetRepository<Actuals, ActualsLog, Guid> _repository;

        public ActualsService(IBaseLogBudgetRepository<Actuals, ActualsLog, Guid> repository, IBudgetUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
        }

        public override void Update(Actuals entity)
        {
            Actuals dbActuals = this.Get(entity.Id);



            base.Update(dbActuals);

        }

        public IEnumerable<Actuals> GetByActualsId(string bgtId)
        {
            return this.GetAll().Where(info => info.BudgetId == bgtId);
        }


    }
}
