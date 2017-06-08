using Data.Infrastructure;
using Data.Repositories.OperatorsRepositories;
using Entities.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OryxBudgetService.OperatorsServices
{
    public class WellService : BaseBudgetService<Well>
    {
        private readonly WellRepository _wellRepo;

        public WellService(WellRepository wellRepo, IBudgetUnitOfWork unitOfWork) 
            : base(wellRepo, unitOfWork)
        {
            _wellRepo = wellRepo;
        }

        public override void Update(Well entity)
        {
            var well = this.Get(entity.Id);
            base.Update(well);
        }

        public IEnumerable<Well> GetByFieldId(string fieldId)
        {
            return this.GetAll().Where(info => info.FieldId == fieldId);
        }
    }
}
