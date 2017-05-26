using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Entities.Budgets;
using OryxBudgetService.BudgetsServices;
using OryxWebapi.Utilities.ActionFilters;
using OryxBudgetService.ViewModels.BudgetsViewModels;
using OryxBudgetService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OryxWebapi.Utilities;
using System.IO;
using Hangfire;

namespace OryxBudgetService.Controllers.BudgetLineControllers
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

    };
}
        
    