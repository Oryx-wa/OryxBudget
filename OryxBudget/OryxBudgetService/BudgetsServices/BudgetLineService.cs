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

        public void UpdateNapimsReview(string napimsUserType, BudgetLine budgetEntity, string code)
        {
            var budgetLine = this.GetAll()
                .Where(b => b.Code == code && b.BudgetId == budgetEntity.BudgetId ).FirstOrDefault();

            var forSaveBd = this.Get(budgetLine.Id);

            if (napimsUserType.Equals("TecCom"))
                budgetLine = CreateBudgetLineForTecCom(budgetEntity, forSaveBd);
            else if (napimsUserType.Equals("SubCom"))
                budgetLine = CreateBudgetLineForSubCom(budgetEntity, forSaveBd);
            else if (napimsUserType.Equals("MalCom"))
                budgetLine = CreateBudgetLineForMalCom(budgetEntity, forSaveBd);

            base.Update(budgetLine);
           
        }

        private BudgetLine CreateBudgetLineForMalCom(BudgetLine budgetEntity , BudgetLine bd)
        {
           
            if (bd != null)
            {
                bd.BudgetId = budgetEntity.BudgetId;
                bd.RowNumber = budgetEntity.RowNumber;
                bd.MalComBudgetFC = budgetEntity.MalComBudgetFC;
                bd.MalComBudgetLC = budgetEntity.MalComBudgetLC;
                bd.MalComBudgetUSD = budgetEntity.MalComBudgetUSD;
            }

            return bd;
        }

        private BudgetLine CreateBudgetLineForSubCom(BudgetLine budgetEntity,  BudgetLine bd)
        {
            
                
            if (budgetEntity != null)
            {
                bd.BudgetId = budgetEntity.BudgetId;
                bd.RowNumber = budgetEntity.RowNumber;
                bd.SubComBudgetFC = budgetEntity.SubComBudgetFC;
                bd.SubComBudgetLC = budgetEntity.SubComBudgetLC;
                bd.SubComBudgetUSD = budgetEntity.SubComBudgetUSD;
            }

            return bd;
        }

        private BudgetLine CreateBudgetLineForTecCom(BudgetLine budgetEntity, BudgetLine bd)
        {
            
            if (bd != null)
            {
                bd.BudgetId = budgetEntity.BudgetId;
                bd.RowNumber = budgetEntity.RowNumber;
                bd.TecComBudgetFC = budgetEntity.TecComBudgetFC;
                bd.TecComBudgetLC = budgetEntity.TecComBudgetLC;
                bd.TecComBudgetUSD = budgetEntity.TecComBudgetUSD;
            }

            return bd;
        }
    }
}
