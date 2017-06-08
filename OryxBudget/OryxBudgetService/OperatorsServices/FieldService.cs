using Data.Infrastructure;
using Data.Repositories.OperatorsRepositories;
using Entities.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OryxBudgetService.OperatorsServices
{
    public class FieldService : BaseBudgetService<Field>
    {
        private readonly FieldRepository _fieldRepo;

        public FieldService(FieldRepository fieldRepo, IBudgetUnitOfWork unitOfWork)
            : base(fieldRepo, unitOfWork)
        {
            _fieldRepo = fieldRepo;
        }

        public override void Update(Field entity)
        {
            var field = this.Get(entity.Id);
            base.Update(field);
        }

        public IEnumerable<Field> GetByConcessionId(string consessionId)
        {
            return this.GetAll().Where(f => f.ConessionId == consessionId);
        }
    }
}
