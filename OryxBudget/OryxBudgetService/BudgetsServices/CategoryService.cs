using Data.Infrastructure;
using Data.Repositories;
using Entities.Budgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OryxBudgetService.BudgetsServices
{
    public class CategoryService : BaseBudgetService<Category>
    {
        private readonly IBaseLogBudgetRepository<Category, CategoryLog, Guid> _repository;

        public CategoryService(IBaseLogBudgetRepository<Category, CategoryLog, Guid> repository, IBudgetUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
        }

        public override void Update(Category entity)
        {
            Category dbCategory = this.Get(entity.Id);
           

            base.Update(dbCategory);

        }

        public IEnumerable<Category> GetByCode(string code)
        {
            return this.GetAll().Where(info => info.Code == code);
        }

        
    }
}
