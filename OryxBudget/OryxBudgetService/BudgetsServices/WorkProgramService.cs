using Data.Infrastructure;
using Data.Repositories.BudgetsRepositories.WorkPrograms;
using Entities.Budgets;
using Entities.Budgets.WorkPrograms;
using OryxSecurity.Services;
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
        private readonly WorkProgramStatusRepository _workProgramStatusRepo;
        protected IUserResolverService _userResolverService;

        public WorkProgramService(ExplorationWorkProgramRepository explorationWorkProgramRepo,
            WorkProgramTypeRepository workProgramTypeRepo,
            DrillingCostTypeRepository drillingCostTypeRepo, DrillingCostRepository drillingCostRepo,
            WorkProgramStatusRepository workProgramStatusRepo, IUserResolverService userResolverService,
            IBudgetUnitOfWork unitOfWork) : base(explorationWorkProgramRepo, unitOfWork)
        {
            _explorationWorkProgramRepo = explorationWorkProgramRepo;
            _workProgramTypeRepo = workProgramTypeRepo;
            _drillingCostTypeRepo = drillingCostTypeRepo;
            _drillingCostRepo = drillingCostRepo;
            _workProgramStatusRepo = workProgramStatusRepo;
            _userResolverService = userResolverService;
        }
        #region "old"
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
        #endregion
        public void AddWorkProgramStatus(WorkProgramStatus entity)
        {


            _workProgramStatusRepo.Add(entity);
        }

        public WorkProgramStatus AddWorkProgramStatus(string dept, string status, Guid budgetId)
        {
            var roleList = _userResolverService.GetRoles();
            // string userType = "";
            string userName = _userResolverService.GetUserName();
            BudgetStatus bdStatus = BudgetStatus.SubCom;
            foreach (var item in roleList)
            {

                if (item.EndsWith("Com"))
                {
                    Enum.TryParse(item, out BudgetStatus bdStatusOut);
                    bdStatus = bdStatusOut;
                }

            }
            Enum.TryParse(dept, out WorkProgramTypeEnum workPrg);
            Enum.TryParse(status, out SignOffStatus signOff);
            WorkProgramStatus entity = new WorkProgramStatus();
            entity.BudgetId = budgetId;
            entity.WorkProgram = workPrg;
            entity.BudgetStatus = BudgetStatus.Operator;
            _workProgramStatusRepo.Add(entity);
            return entity;

        }
        public void UpdateWorkProgramStatus(WorkProgramStatus entity)
        {
            var status = _workProgramStatusRepo.Get(entity.Id);
            _workProgramStatusRepo.Update(status);
        }

        public void updateStatusHistory(Guid id, SignOffStatus status)
        {
            var wrkPrg = _workProgramStatusRepo.Get(id);
            WorkProgramStatusHistory hist = new WorkProgramStatusHistory();
            hist.ProgramStatus = status;
            _workProgramStatusRepo.Update(wrkPrg);
        }

        public IEnumerable<WorkProgramStatus> GetAllWorkProgramStatuses()
        {
            return _workProgramStatusRepo.GetAll();
        }

        public WorkProgramStatus GetWorkProgramStatusesByBudget(string budgetId)
        {
            var roleList = _userResolverService.GetRoles();
            WorkProgramTypeEnum t = WorkProgramTypeEnum.Header;
           
            foreach (var item in roleList)
            {
                if (Enum.TryParse(item, out WorkProgramTypeEnum wkTypeOut))
                {
                    t = wkTypeOut;
                }

            }
            return this.GetAllWorkProgramStatuses()
                .Where(s => s.BudgetId == new Guid(budgetId) && s.WorkProgram == t )
                .FirstOrDefault();
        }

        public WorkProgramStatus GetWorkProgramStatusesById(Guid id)
        {
            return _workProgramStatusRepo.Get(id);
        }
    }
}
