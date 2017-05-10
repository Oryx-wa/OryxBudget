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

namespace OryxBudgetService.BudgetsServices
{
    public class BudgetService : BaseBudgetService<Budget>
    {
        private readonly BudgetRepository _repository;
        private readonly BudgetLineRepository _lineRepository;
        private readonly BudgetCodeService _budgetCodeService;

        public BudgetService(BudgetRepository repository, BudgetCodeService budgetCodeService,
            BudgetLineRepository lineRepository, IBudgetUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
            _lineRepository = lineRepository;
            _budgetCodeService = budgetCodeService;
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

        public IEnumerable<BudgetCodeView> GetOperatorBudget(string id)
        {
            var budgets = this.GetAllIncluding()
                .Where(b => b.OperatorId == id)
                .FirstOrDefault().BudgetLines
                .GroupBy(b => b.Code)
                .Select(newb => new {
                    Code = newb.Key,
                    BudgetAmount = newb.Sum(c => c.BudgetAmount),
                    BudgetAmountLC = newb.Sum(c => c.AmountLC),
                    BudgetAmountUSD = newb.Sum(c => c.AmountUSD)
                });
                

            var codes = _budgetCodeService.GenerateCodeView();

            var budgetView = from c in codes
                             join b in budgets
                             on c.Code equals b.Code
                             select new { c, b };

            foreach (var match in budgetView)
            {
                match.c.BudgetAmount = match.b.BudgetAmount;
                match.c.BudgetAmountLC = match.b.BudgetAmountLC;
                match.c.BudgetAmountUSD = match.b.BudgetAmountUSD;
    
            }

            return budgetView.Select(c => c.c).ToList();

            
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
            return _repository.AllIncluding(c => c.BudgetLines).ToList();
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


    }
}
