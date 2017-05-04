using Data.Infrastructure;
using Entities.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repositories;
using OryxBudgetService;

namespace OryxBudgetService.OperatorsServices
{
    public class OperatorTypeService : BaseBudgetService<OperatorType>
    {
        private readonly IBaseLogBudgetRepository<OperatorType, OperatorTypeLog, Guid> _repository;

        public OperatorTypeService(IBaseLogBudgetRepository<OperatorType, OperatorTypeLog, Guid> repository, IBudgetUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
        }

        public override void Update(OperatorType entity)
        {
            OperatorType dbOperatorType = this.Get(entity.Id);



            base.Update(dbOperatorType);

        }

        public IEnumerable<OperatorType> GetByOperatorTypeId(string operatorId)
        {
            return this.GetAll().Where(info => info.Operator == operatorId);
        }


    }
}
