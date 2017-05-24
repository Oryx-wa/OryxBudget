using CsvHelper;
using Data.Infrastructure;
using Data.Repositories;
using Data.Repositories.BudgetsRepositories;
using Entities.Budgets;
using OryxBudgetService.CsvMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OryxBudgetService.BudgetsServices
{
    public class BudgetLineService : BaseBudgetService<BudgetLine>
    {
        private readonly IBaseLogBudgetRepository<BudgetLine, BudgetLineLog, Guid> _repository;
        private readonly LineCommentRepository _lineCommentRepository;

        public BudgetLineService(IBaseLogBudgetRepository<BudgetLine, BudgetLineLog, Guid> repository, IBudgetUnitOfWork unitOfWork,
            LineCommentRepository lineCommentRepository) : base(repository, unitOfWork)
        {
            _repository = repository;
            _lineCommentRepository = lineCommentRepository;
        }

        public override void Update(BudgetLine entity)
        {
            BudgetLine dbBudgetLine = this.Get(entity.Id);
           


            base.Update(dbBudgetLine);

        }

        public IEnumerable<BudgetLine> GetByBudgetId(string bgtId)
        {
            return this.GetAll().Where(info => info.BudgetId.ToString() == bgtId);
        }

        public void uploadEntity(string fileName)
        {
            var file = System.IO.File.OpenRead(fileName);
            System.IO.TextReader dataFile = new System.IO.StreamReader(file);

            var csv = new CsvReader(dataFile);
            csv.Configuration.RegisterClassMap<BudgetLineMapping>();

            var records = csv.GetRecords<BudgetLine>().ToList();

            foreach (var item in records)
            {
                item.Code = item.Code.Trim();
                item.Description = (item.Description.Trim().Length > 99) ?  item.Description.Trim().Substring(0,99) : item.Description.Trim();    
                
                this.Add(item);

            };
            this.SaveChanges();
            dataFile.Dispose();
            file.Dispose();
            GC.Collect();

            System.IO.File.Delete(fileName);

        }

        public void UpdateNapimsReview(string napimsUserType, BudgetLine budgetEntity, LineComment lineCommentEntity)
        {
            var budgetLine = this.Get(budgetEntity.Id);

            if (napimsUserType.Equals("TecCom"))
                budgetLine = CreateBudgetLineForTecCom(budgetEntity);
            else if (napimsUserType.Equals("SubCom"))
                budgetLine = CreateBudgetLineForSubCom(budgetEntity);
            else if (napimsUserType.Equals("MalCom"))
                budgetLine = CreateBudgetLineForMalCom(budgetEntity);

            base.Update(budgetLine);
            this.SaveChanges();

            //Add LineComment
            _lineCommentRepository.Add(lineCommentEntity);
            base.SaveChanges();
        }

        private BudgetLine CreateBudgetLineForMalCom(BudgetLine budgetEntity)
        {
            var budgetLine = _repository.Get(budgetEntity.Id);
            if (budgetLine != null)
            {
                budgetLine.BudgetId = budgetEntity.BudgetId;
                budgetLine.RowNumber = budgetEntity.RowNumber;
                budgetLine.MalComBudgetFC = budgetEntity.MalComBudgetFC;
                budgetLine.MalComBudgetLC = budgetEntity.MalComBudgetLC;
                budgetLine.MalComBudgetUSD = budgetEntity.MalComBudgetUSD;
            }

            return budgetLine;
        }

        private BudgetLine CreateBudgetLineForSubCom(BudgetLine budgetEntity)
        {
            var budgetLine = _repository.Get(budgetEntity.Id);
            if (budgetLine != null)
            {
                budgetLine.BudgetId = budgetEntity.BudgetId;
                budgetLine.RowNumber = budgetEntity.RowNumber;
                budgetLine.SubComBudgetFC = budgetEntity.SubComBudgetFC;
                budgetLine.SubComBudgetLC = budgetEntity.SubComBudgetLC;
                budgetLine.SubComBudgetUSD = budgetEntity.SubComBudgetUSD;
            }

            return budgetLine;
        }

        private BudgetLine CreateBudgetLineForTecCom(BudgetLine budgetEntity)
        {
            var budgetLine = _repository.Get(budgetEntity.Id);
            if (budgetLine != null)
            {
                budgetLine.BudgetId = budgetEntity.BudgetId;
                budgetLine.RowNumber = budgetEntity.RowNumber;
                budgetLine.TecComBudgetFC = budgetEntity.TecComBudgetFC;
                budgetLine.TecComBudgetLC = budgetEntity.TecComBudgetLC;
                budgetLine.TecComBudgetUSD = budgetEntity.TecComBudgetUSD;
            }

            return budgetLine;
        }
    }
}
