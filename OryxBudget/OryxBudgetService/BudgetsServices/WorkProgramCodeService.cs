using Data.Infrastructure;
using Data.Repositories.BudgetsRepositories;
using Entities.Budgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OryxBudgetService.BudgetsServices
{
    public class WorkProgramCodeService : BaseBudgetService<WorkProgramCode>
    {
        private readonly WorkProgramCodeRepository _wpcRepo;

        public WorkProgramCodeService(WorkProgramCodeRepository wpcRepo, IBudgetUnitOfWork unitOfWork)
            : base(wpcRepo, unitOfWork)
        {
            _wpcRepo = wpcRepo;
        }

        public override void Update(WorkProgramCode entity)
        {
            WorkProgramCode wpc = this.Get(entity.Id);
            base.Update(wpc);
        }

        public IEnumerable<WorkProgramCode> GetByBudgetCode(string code)
        {
            return this.GetAll().Where(info => info.BudgetCode == code);
        }

        public IEnumerable<WorkProgramCode> GetAllProgramCodes() {
            return this.GetAll();
        }

        public IEnumerable<WorkProgramCode> GetById(string id)
        {
            return this.GetAll().Where(info => info.Id.ToString() == id);
        }
    }
}
