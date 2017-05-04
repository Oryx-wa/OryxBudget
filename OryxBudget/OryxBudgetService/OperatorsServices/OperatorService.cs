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
    public class OperatorService : BaseBudgetService<Operator>
    {
        private readonly IBaseLogBudgetRepository<Operator, OperatorLog, Guid> _repository;

        public OperatorService(IBaseLogBudgetRepository<Operator, OperatorLog, Guid> repository, IBudgetUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
        }

        public override void Update(Operator entity)
        {
            Operator dbOperator = this.Get(entity.Id);



            base.Update(dbOperator);

        }

        public IEnumerable<Operator> GetByOperatorId(string codeId)
        {
            return this.GetAll().Where(info => info.Code == codeId);
        }


    }
}
