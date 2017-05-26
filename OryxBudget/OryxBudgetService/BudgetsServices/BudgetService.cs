using Data.Infrastructure;
using Entities.Budgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repositories;
using CsvHelper;
using OryxBudgetService.CsvMapping;
using Data.Repositories.BudgetsRepositories;
using OryxBudgetService.Utilties;
using Data.Repositories.OperatorsRepositories;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using OryxBudgetService.Utilities.SignalRHubs;

namespace OryxBudgetService.BudgetsServices
{
    public class BudgetService : BaseBudgetService<Budget>
    {
        private readonly BudgetRepository _repository;
        private readonly BudgetLineRepository _lineRepository;
        private readonly BudgetCodeService _budgetCodeService;
        private readonly LineCommentRepository _lineCommentRepository;
        private readonly OperatorRepository _operatorRepository;
        private readonly IConnectionManager _connectionManager;

        public BudgetService(BudgetRepository repository, BudgetCodeService budgetCodeService,
            BudgetLineRepository lineRepository, IBudgetUnitOfWork unitOfWork, LineCommentRepository lineCommentRepository,
            OperatorRepository operatorRepository, IConnectionManager signalRConnectionManager) : base(repository, unitOfWork)
        {
            _repository = repository;
            _lineRepository = lineRepository;
            _budgetCodeService = budgetCodeService;
            _lineCommentRepository = lineCommentRepository;
            _operatorRepository = operatorRepository;
            _connectionManager = signalRConnectionManager;
            
        }

        public override void Update(Budget entity)
        {
            Budget dbBudget = this.Get(entity.Id);
            base.Update(dbBudget);

        }

        public IEnumerable<Budget> GetByPeriodId(string periodId)
        {
            return this.GetAll().Where(info => info.PeriodId == periodId);
        }

        public IEnumerable<Budget> GetByOperatorId(string operatorId)
        {
            return this.GetAll().Where(info => info.OperatorId == operatorId);
        }

        public IEnumerable<OperatorBudget> GetOperatorBudget(string id)
        {
            return _repository.GetOperatorBudget(id);         


        }

        public void InitializeBudgetForAllOperators(string periodId, string description)
        {
            var operators = _operatorRepository.GetAll()
                .Where(o => o.Status.Equals("A")).ToList();

            foreach(var op in operators)
            {
                var budget = new Budget
                {
                    CreateDate = DateTime.Now,
                    Description = op.Name + "_" + description,
                    OperatorId = op.Id.ToString(),
                    PeriodId = periodId,
                    Status = "A",
                    OpBudgetFC = 0,
                    UpdateDate = DateTime.Now,
                    UserSign = "e317f2dc-deb1-4463-8b67-7f435211d652",
                    OpBudgetLC = 0,
                    OpBudgetUSD = 0,
                    OpActualFC = 0,
                    OpActualLC = 0,
                    OpActualUSD = 0
                };

                base.Add(budget);
                base.SaveChanges();
            }
        }

        public void UploadBudget(string fileName, Guid id)
        {
            var file = System.IO.File.OpenRead(fileName);
            System.IO.TextReader dataFile = new System.IO.StreamReader(file);

            var csv = new CsvReader(dataFile);
            csv.Configuration.RegisterClassMap<BudgetLineMapping>();

            var records = csv.GetRecords<BudgetLine>().ToList();

            var budget = this.Get(id);
            decimal totalUSD = budget.OpBudgetUSD;
            decimal totalLC = budget.OpBudgetLC;
            decimal total = budget.OpBudgetFC;

            foreach (var item in records)
            {
                var code = _budgetCodeService.GetByBudgetCodeByCode(item.Code);
                if (!code.Postable.Trim().Equals("Y"))
                {
                    continue;
                }
                item.Code = item.Code.Trim();
                item.Description = (item.Description.Trim().Length > 99) ? item.Description.Trim().Substring(0, 99) : item.Description.Trim();
                item.UserSign = "e317f2dc-deb1-4463-8b67-7f435211d652";
                item.UpdateDate = System.DateTime.Now;
                item.CreateDate = System.DateTime.Now;
                budget.BudgetLines.Add(item);
                totalLC += item.OpBudgetLC;
                totalUSD += item.OpBudgetUSD;
                total += item.OpBudgetLCInUSD + item.OpBudgetUSD;

            };

            budget.OpBudgetLC = totalLC;
            budget.OpBudgetUSD = totalUSD;
            budget.OpBudgetFC = total;

            base.Update(budget);
            this.SaveChanges();
            dataFile.Dispose();
            file.Dispose();
            GC.Collect();

            System.IO.File.Delete(fileName);
            var hubContext = _connectionManager.GetHubContext<NotificationHub>();
            hubContext.Clients.All.

        }

        public void UploadActual(string fileName, Guid id)
        {
            var file = System.IO.File.OpenRead(fileName);
            System.IO.TextReader dataFile = new System.IO.StreamReader(file);

            var csv = new CsvReader(dataFile);
            csv.Configuration.RegisterClassMap<BudgetActualMapping>();

            var records = csv.GetRecords<Actual>().ToList();

            var budget = this.Get(id);
            decimal totalUSD = budget.OpActualUSD;
            decimal totalLC = budget.OpActualLC;
            decimal total = budget.OpActualFC;

            foreach (var item in records)
            {
                var code = _budgetCodeService.GetByBudgetCodeByCode(item.Code);
                if (!code.Postable.Trim().Equals("Y"))
                {
                    continue;
                }
                item.Code = item.Code.Trim();
                item.Description = (item.Description.Trim().Length > 99) ? item.Description.Trim().Substring(0, 99) : item.Description.Trim();
                item.UserSign = "e317f2dc-deb1-4463-8b67-7f435211d652";
                item.UpdateDate = System.DateTime.Now;
                item.CreateDate = System.DateTime.Now;

                budget.Actuals.Add(item);
                totalLC += item.OpActualLC;
                totalUSD += item.OpActualUSD;
                total += item.OpActualLCInUSD + item.OpActualUSD;

            };

            budget.OpActualLC = totalLC;
            budget.OpActualUSD = totalUSD;
            budget.OpActualFC = total;

            base.Update(budget);
            this.SaveChanges();
            dataFile.Dispose();
            file.Dispose();
            GC.Collect();

            System.IO.File.Delete(fileName);

        }

        public IEnumerable<Budget> GetAllIncluding()
        {
            return _repository.AllIncluding(c => c.BudgetLines, c => c.Actuals).ToList();
        }

        public Budget GetAllIncluding(Guid id, bool noTracking = false)
        {
            if (noTracking)
            {
                return _repository.AllIncludingNoTracking(c => c.BudgetLines).Where(c => c.Id == id).FirstOrDefault();
            }
            else
            {
                return _repository.AllIncluding(c => c.BudgetLines).Where(c => c.Id == id).FirstOrDefault();
            }

        }

        public IEnumerable<BudgetCodeView> GetBudgetDetails(string id)
        {
            
          return _repository.GetBudgetLines(id);
            
        }

        public IEnumerable<LineComment> GetLineComment(string id, string code)
        {
            return _lineCommentRepository.GetAll().Where(c => c.BudgetId.ToString() == id && c.Code == code);
        }

        public void AddLineComments (IEnumerable<LineComment> lineComments)
        {
            foreach (var item in lineComments)
            {
                if (item.Id == Guid.Empty)
                {
                    this._lineCommentRepository.Add(item);
                }
                else
                {
                    this._lineCommentRepository.Update(item);
                }
               
            }
        }
    }


}
