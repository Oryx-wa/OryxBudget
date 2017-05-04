using Data.Infrastructure;
using Data.Repositories;
using Entities.Budgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OryxBudgetService.BudgetsServices
{
    public class BudgetLineCategoryService : BaseBudgetService<BudgetLineCategory>
    {
        private readonly IBaseLogBudgetRepository<BudgetLineCategory, BudgetLineCategoryLog, Guid> _repository;

        public BudgetLineCategoryService(IBaseLogBudgetRepository<BudgetLineCategory, BudgetLineCategoryLog, Guid> repository, IBudgetUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
        }

        public override void Update(BudgetLineCategory entity)
        {
            BudgetLineCategory dbBudgetLineCategory = this.Get(entity.Id);
           

            base.Update(dbBudgetLineCategory);

        }

        public IEnumerable<BudgetLineCategory> GetByCode(string code)
        {
            return this.GetAll().Where(info => info.Code == code);
        }

        
    }
}
