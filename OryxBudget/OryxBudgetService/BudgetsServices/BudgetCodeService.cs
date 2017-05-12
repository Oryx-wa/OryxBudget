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

        public BudgetCode GetByBudgetCodeByCode(string code)
        {
            return this.GetAll().Where(info => info.Code == code).FirstOrDefault();
        }

        public void UploadEntity(string fileName)
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

        //public IEnumerable<BudgetCodeView> GenerateCodeView()
        //{
        //    var Level1Codes = this.GetAll().Where(code => code.Level == "1");
        //    var Level2Codes = this.GetAll().Where(code => code.Level == "2");
        //    var Level3Codes = this.GetAll().Where(code => code.Level == "3");

        //    IList<BudgetCodeView> codeList = new List<BudgetCodeView>();

        //    foreach (var item in Level1Codes)
        //    {
        //        BudgetCodeView codeView = new BudgetCodeView();
        //        codeView.Code = item.Code;
        //        codeView.Description = item.Description;
        //        codeView.Level = 1;
        //        codeView.Level2 = "";
        //        codeView.level2Description = "";
        //        codeView.FatherNum = item.FatherNum;

        //        codeView.Level1 = "";



        //        codeList.Add(codeView);
        //    }

        //    foreach (var item in Level2Codes)
        //    {
        //        BudgetCodeView codeView = new BudgetCodeView();
        //        codeView.Code = item.Code;
        //        codeView.Description = item.Description;
        //        codeView.Level = 2;
        //        codeView.Level1 = item.FatherNum;
        //        codeView.Level2 = "";
        //        codeView.level2Description = "";
        //        codeView.FatherNum = item.FatherNum;

        //        codeView.level1Description = Level1Codes
        //            .FirstOrDefault(c => c.Code == item.FatherNum).Description;

        //        codeList.Add(codeView);
        //    }

        //    foreach (var item in Level3Codes)
        //    {
        //        BudgetCodeView codeView = new BudgetCodeView();
        //        codeView.Code = item.Code;
        //        codeView.Description = item.Description;
        //        codeView.Level = 3;
        //        codeView.Level2 = item.FatherNum;
        //        codeView.FatherNum = item.FatherNum;
        //        var level2 = Level2Codes
        //             .FirstOrDefault(c => c.Code == item.FatherNum);

        //        codeView.level2Description = level2.Description;

        //        var level1 = Level1Codes.FirstOrDefault(c => c.Code == level2.FatherNum);

        //        codeView.Level1 = level1.Code;
        //        codeView.level1Description = level1.Description;                

        //        codeList.Add(codeView);
        //    }

        //    return codeList;

        //}

    }
}
