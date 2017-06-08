using Data.Infrastructure;
using Data.Repositories.BudgetsRepositories.WorkPrograms;
using Entities.Budgets.WorkPrograms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OryxBudgetService.BudgetsServices
{
    public class WorkProgramService : BaseBudgetService<ExplorationWorkProgram>
    {
        private readonly ExplorationWorkProgramRepository _explorationWorkProgramRepo;
        private readonly WorkProgramTypeRepository _workProgramTypeRepo;
        private readonly DrillingCostTypeRepository _drillingCostTypeRepo;
        private readonly DrillingCostRepository _drillingCostRepo;

        public WorkProgramService(ExplorationWorkProgramRepository explorationWorkProgramRepo,
            WorkProgramTypeRepository workProgramTypeRepo,
            DrillingCostTypeRepository drillingCostTypeRepo, DrillingCostRepository drillingCostRepo,
            IBudgetUnitOfWork unitOfWork) : base(explorationWorkProgramRepo, unitOfWork)
        {
            _explorationWorkProgramRepo = explorationWorkProgramRepo;
            _workProgramTypeRepo = workProgramTypeRepo;
            _drillingCostTypeRepo = drillingCostTypeRepo;
            _drillingCostRepo = drillingCostRepo;
        }

        public override void Update(ExplorationWorkProgram entity)
        {
            var explorationWorkProgram = this.Get(entity.Id);
            base.Update(explorationWorkProgram);
        }

        public IEnumerable<ExplorationWorkProgram> GetByCode(string code)
        {
            return this.GetAll().Where(ewp => ewp.BudgetCode == code);
        }

        public IEnumerable<ExplorationWorkProgram> GetByBudgetLine(string lineId)
        {
            return this.GetAll().Where(ewp => ewp.BudgetLineId == new Guid(lineId));
        }

        public void AddWorkProgramType(WorkProgramType entity)
        {
            _workProgramTypeRepo.Add(entity);
        }

        public void UpdateWorkProgramType(WorkProgramType entity)
        {
            var wptObj = _workProgramTypeRepo.Get(entity.Id);
            _workProgramTypeRepo.Update(wptObj);
        }

        public IEnumerable<WorkProgramType> GetAllWorkProgramTypes()
        {
            return _workProgramTypeRepo.GetAll();
        }

        public void AddDrillingCostType(DrillingCostType entity)
        {
            _drillingCostTypeRepo.Add(entity);
        }

        public void UpdateDrillingCostType(DrillingCostType entity)
        {
            var drillingCostType = _drillingCostTypeRepo.Get(entity.Id);
            _drillingCostTypeRepo.Update(drillingCostType);
        }

        public IEnumerable<DrillingCostType> GetAllDrillCostTypes()
        {
            return _drillingCostTypeRepo.GetAll();
        }

        public void AddDrillingCost(DrillingCost entity)
        {
            _drillingCostRepo.Add(entity);
        }

        public void UpdateDrillingCost(DrillingCost entity)
        {
            var drillingCost = _drillingCostRepo.Get(entity.Id);
            _drillingCostRepo.Update(drillingCost);
        }

        public IEnumerable<DrillingCost> GetAllDrillCosts()
        {
            return _drillingCostRepo.GetAll();
        }
    }
}
