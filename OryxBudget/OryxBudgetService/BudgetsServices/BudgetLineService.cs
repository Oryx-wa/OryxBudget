using CsvHelper;
using Data.Infrastructure;
using Data.Repositories;
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

        public BudgetLineService(IBaseLogBudgetRepository<BudgetLine, BudgetLineLog, Guid> repository, IBudgetUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
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


    }
}
