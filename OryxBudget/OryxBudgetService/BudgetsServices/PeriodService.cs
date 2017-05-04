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
   public class PeriodService : BaseBudgetService<Period>
    {
        private readonly IBaseLogBudgetRepository<Period, PeriodLog, Guid> _repository;

        public PeriodService(IBaseLogBudgetRepository<Period, PeriodLog, Guid> repository, IBudgetUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
        }

        public override void Update(Period entity)
        {
            Period dbPeriod = this.Get(entity.Id);



            base.Update(dbPeriod);

        }

        public IEnumerable<Period> GetByPeriodId(string periodId)
        {
            return this.GetAll().Where(info => info.Description == periodId);
        }


    }
}
