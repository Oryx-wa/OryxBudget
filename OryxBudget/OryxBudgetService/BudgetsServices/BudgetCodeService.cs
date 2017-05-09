using CsvHelper;
using Data.Infrastructure;
using Data.Repositories;
using Entities.Budgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OryxBudgetService.CsvMapping;

namespace OryxBudgetService.BudgetsServices
{
   public class BudgetCodeService : BaseBudgetService<BudgetCode>
    {
        private readonly IBaseLogBudgetRepository<BudgetCode, BudgetCodeLog, Guid> _repository;

        public BudgetCodeService(IBaseLogBudgetRepository<BudgetCode, BudgetCodeLog, Guid> repository, IBudgetUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
        }

        public override void Add(BudgetCode entity)
        {

           
            

            base.Add(entity);
        }

        public override void Update(BudgetCode entity)
        {
            BudgetCode dbBudgetCodes = this.Get(entity.Id);



            base.Update(dbBudgetCodes);

        }

        public IEnumerable<BudgetCode> GetByBudgetCodesId(string bgtCode)
        {
            return this.GetAll().Where(info => info.Code == bgtCode);
        }

        public void uploadEntity(string fileName)
        {
            var file = System.IO.File.OpenRead(fileName);
            System.IO.TextReader dataFile = new System.IO.StreamReader(file);

            var csv = new CsvReader(dataFile);
            csv.Configuration.RegisterClassMap<BudgetCodeMapping>();

            var records = csv.GetRecords<BudgetCode>().ToList();

            foreach (var item in records)
            {
                item.Code = item.Code.Trim();
                item.Description = item.Description.Trim();
                item.SecondDescription = item.SecondDescription.Trim();
                item.Level = item.Level.Trim();
                item.Active = item.Active.Trim();
                item.Postable = item.Postable.Trim();
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
