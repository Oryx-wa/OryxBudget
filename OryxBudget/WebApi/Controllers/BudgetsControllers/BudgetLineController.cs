using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Entities.Budgets;
using OryxBudgetService.BudgetsServices;
using OryxWebapi.Utilities.ActionFilters;
using OryxWebApi.ViewModels.BudgetsViewModels;
using OryxBudgetService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OryxWebapi.Utilities;
using System.IO;
using Hangfire;

namespace OryxWebApi.Controllers.BudgetLineControllers
{
    public class BudgetLineController : BaseController
    {
        private readonly BudgetLineService _budgetLineService;
        // private readonly AccreditationInfoService _accreditationInfoService;
        // private readonly TrainingInfoService _trainingInfoService;

        public BudgetLineController(BudgetLineService budgetLineService)
        {
            _budgetLineService = budgetLineService;
            //  _accreditationInfoService = accreditationInfoService;
            //  _trainingInfoService = trainingInfoService;
        }

        // POST api/values
        [HttpPost] [ValidateModelState]
        [Route("Add")]
        public JsonResult Add([FromBody] BudgetLineViewModel BudgetLineVm)
        {

            var budgetLine = Mapper.Map<BudgetLine>(BudgetLineVm);
            _budgetLineService.Add(budgetLine);
            _budgetLineService.SaveChanges();
            return Json(_budgetLineService.Get(budgetLine.Id));

        }

        [HttpPost] [ValidateModelState]
        [Route("Update")]
        public JsonResult Update([FromBody]BudgetLineViewModel BudgetLineVm)
        {
            var budgetLine = Mapper.Map<BudgetLine>(BudgetLineVm);
            _budgetLineService.Update(budgetLine);
            _budgetLineService.SaveChanges();
            return Json(_budgetLineService.Get(budgetLine.Id));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet]
        public override JsonResult Get()
        {
            return Json(_budgetLineService.GetAll());
        }


        [HttpGet]
        [Route("GetById")]
        public JsonResult Get(string id)
        {
            return Json(_budgetLineService.Get(ConvertToGuid(id)));
        }

        [Route("Upload")]
        [HttpPost]
        public JsonResult UploadBasicInfo(IFormFile file)
        {

            var fileName = string.Concat("Uploads", "\\", Helpers.RandomString(10), ".csv");

            using (FileStream fs = System.IO.File.Create(fileName))
            {
                file.CopyTo(fs);
                fs.Flush();
                fs.Dispose();
            }
            BackgroundJob.Enqueue(() => _budgetLineService.uploadEntity(fileName));

            return Json("File Uploaded"); //null just to make error free
        }

        [Route("UpdateNapimsBudgetFigures")]
        [HttpPost]
        public JsonResult UpdateNapimsBudgetFigures(string napimsUserType, [FromBody]NapimsBudgetViewModel napimsBudgetVm)
        {
            var budgetLine = new BudgetLine();
            if (napimsUserType.Equals("TecCom"))
            {
                budgetLine = CreateBudgetLineForTecCom(napimsBudgetVm);
            }
            else if (napimsUserType.Equals("SubCom"))
                budgetLine = CreateBudgetLineForSubCom(napimsBudgetVm);
            else if (napimsUserType.Equals("MalCom"))
                budgetLine = CreateBudgetLineForMalCom(napimsBudgetVm);

            _budgetLineService.Update(budgetLine);
            _budgetLineService.SaveChanges();
            return Json(_budgetLineService.Get(budgetLine.Id));
        }

        private BudgetLine CreateBudgetLineForMalCom(NapimsBudgetViewModel napimsBudgetVm)
        {
            var budgetLine = _budgetLineService.Get(napimsBudgetVm.Id);
            if (budgetLine != null)
            {
                budgetLine.BudgetId = new Guid(napimsBudgetVm.BudgetId);
                budgetLine.RowNumber = napimsBudgetVm.RowNumber;
                budgetLine.MalComBudgetFC = napimsBudgetVm.MalComBudgetFC;
                budgetLine.MalComBudgetLC = napimsBudgetVm.MalComBudgetLC;
                budgetLine.MalComBudgetUSD = napimsBudgetVm.MalComBudgetUSD;
            }

            return budgetLine;
        }

        private BudgetLine CreateBudgetLineForSubCom(NapimsBudgetViewModel napimsBudgetVm)
        {
            var budgetLine = _budgetLineService.Get(napimsBudgetVm.Id);
            if (budgetLine != null)
            {
                budgetLine.BudgetId = new Guid(napimsBudgetVm.BudgetId);
                budgetLine.RowNumber = napimsBudgetVm.RowNumber;
                budgetLine.SubComBudgetFC = napimsBudgetVm.SubComBudgetFC;
                budgetLine.SubComBudgetLC = napimsBudgetVm.SubComBudgetLC;
                budgetLine.SubComBudgetUSD = napimsBudgetVm.SubComBudgetUSD;
            }

            return budgetLine;
        }

        private BudgetLine CreateBudgetLineForTecCom(NapimsBudgetViewModel napimsBudgetVm)
        {
            var budgetLine = _budgetLineService.Get(napimsBudgetVm.Id);
            if (budgetLine != null)
            {
                budgetLine.BudgetId = new Guid(napimsBudgetVm.BudgetId);
                budgetLine.RowNumber = napimsBudgetVm.RowNumber;
                budgetLine.TecComBudgetFC = napimsBudgetVm.TecComBudgetFC;
                budgetLine.TecComBudgetLC = napimsBudgetVm.TecComBudgetLC;
                budgetLine.TecComBudgetUSD = napimsBudgetVm.TecComBudgetUSD;
            }

            return budgetLine;
        }
    };
}
        
    