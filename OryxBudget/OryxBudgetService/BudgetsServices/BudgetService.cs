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

namespace OryxBudgetService.BudgetsServices
{
    public class BudgetService : BaseBudgetService<Budget>
    {
        private readonly BudgetRepository _repository;
        private readonly BudgetLineRepository _lineRepository;
        private readonly BudgetCodeService _budgetCodeService;
        private readonly LineCommentRepository _lineCommentRepository;

        public BudgetService(BudgetRepository repository, BudgetCodeService budgetCodeService,
            BudgetLineRepository lineRepository, IBudgetUnitOfWork unitOfWork, LineCommentRepository lineCommentRepository) : base(repository, unitOfWork)
        {
            _repository = repository;
            _lineRepository = lineRepository;
            _budgetCodeService = budgetCodeService;
            _lineCommentRepository = lineCommentRepository;
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

        public void UploadBudget(string fileName, Guid id)
        {
            var file = System.IO.File.OpenRead(fileName);
            System.IO.TextReader dataFile = new System.IO.StreamReader(file);

            var csv = new CsvReader(dataFile);
            csv.Configuration.RegisterClassMap<BudgetLineMapping>();

            var records = csv.GetRecords<BudgetLine>().ToList();

            var budget = this.Get(id);
            decimal totalUSD = budget.TotalAmountUSD;
            decimal totalLC = budget.TotalAmountLC;
            decimal total = budget.TotalBudgetAmount;

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
                totalLC += item.AmountLC;
                totalUSD += item.AmountUSD;
                total += item.AmountLCInUSD + item.AmountUSD;

            };

            budget.TotalAmountLC = totalLC;
            budget.TotalAmountUSD = totalUSD;
            budget.TotalBudgetAmount = total;

            base.Update(budget);
            this.SaveChanges();
            dataFile.Dispose();
            file.Dispose();
            GC.Collect();

            System.IO.File.Delete(fileName);

        }

        public void UploadActual(string fileName, Guid id)
        {
            var file = System.IO.File.OpenRead(fileName);
            System.IO.TextReader dataFile = new System.IO.StreamReader(file);

            var csv = new CsvReader(dataFile);
            csv.Configuration.RegisterClassMap<BudgetActualMapping>();

            var records = csv.GetRecords<Actual>().ToList();

            var budget = this.Get(id);
            decimal totalUSD = budget.ActualAmountUSD;
            decimal totalLC = budget.ActualAmountLC;
            decimal total = budget.ActualAmount;

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
                totalLC += item.AmountLC;
                totalUSD += item.AmountUSD;
                total += item.AmountLCInUSD + item.AmountUSD;

            };

            budget.ActualAmountLC = totalLC;
            budget.ActualAmountUSD = totalUSD;
            budget.ActualAmount = total;

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
            IList<BudgetCodeView> bd = new List<BudgetCodeView>();

            var budgetActuals = _repository.GetBudgetActuals(id);
            var budgetCodes = _budgetCodeService.GetAll()
                .Select(c => new { c.Code, c.Description, c.Level, c.FatherNum, c.Postable });

            var budgetView = from b in budgetActuals
                             join c in budgetCodes
                             on b.Code equals c.Code
                             select new
                             {
                                 Code = c.Code,
                                 Description = c.Description,
                                 FatherNum = c.FatherNum,
                                 Level = c.Level,
                                 Budget = b.Budget,
                                 BudgetLC = b.BudgetLC,
                                 BudgetUSD = b.BudgetUSD,
                                 Actual = b.Actual,
                                 ActualLC = b.ActualLC,
                                 ActualUSD = b.ActualUSD
                             };



            foreach (var item in budgetView)
            {
                BudgetCodeView b = new BudgetCodeView();
                b.Actual = item.Actual;
                b.ActualLC = item.ActualLC;
                b.ActualUSD = item.ActualUSD;
                b.Budget = item.Budget;
                b.BudgetLC = item.BudgetLC;
                b.BudgetUSD = item.BudgetUSD;
                b.Code = item.Code;
                b.Description = item.Description;
                b.FatherNum = item.FatherNum;
                b.Level = Convert.ToInt16(item.Level);
                b.BudgetId = id;
                bd.Add(b);
            }
            return bd.ToList();
        }

        public IEnumerable<LineComment> GetLineComment(string id, string code)
        {
            return _lineCommentRepository.GetAll().Where(c => c.BudgetId.ToString() == id && c.Code == code);
        }

        public void AddLineComments (IEnumerable<LineComment> lineComments)
        {
            foreach (var item in lineComments)
            {
                if (item.Id == null)
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
