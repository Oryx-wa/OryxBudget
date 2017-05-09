using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Entities.Budgets;
using OryxBudgetService.BudgetsServices;
using OryxWebapi.Utilities.ActionFilters;
using OryxWebApi.ViewModels.BudgetsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OryxWebapi.Utilities;
using System.IO;
using Hangfire;

namespace OryxWebApi.Controllers.BudgetControllers
{
    public class BudgetController : BaseController
    {
        private readonly BudgetService _budgetService;

        public BudgetController(BudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        // POST api/values
        [HttpPost][ ValidateModelState]
        [Route("Add")]
        public JsonResult Add([FromBody] BudgetViewModel BudgetVm)
        {

            var budget = Mapper.Map<Budget>(BudgetVm);
            _budgetService.Add(budget);
            _budgetService.SaveChanges();
            return Json(_budgetService.Get(budget.Id));

        }

        [HttpPost][ ValidateModelState]
        [Route("Update")]
        public JsonResult Update([FromBody]BudgetViewModel BudgetVm)
        {
            var budget = Mapper.Map<Budget>(BudgetVm);
            _budgetService.Update(budget);
            _budgetService.SaveChanges();
            return Json(_budgetService.Get(budget.Id));
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
            return Json(_budgetService.GetAll());
        }


        [HttpGet]
        [Route("GetById")]
        public JsonResult Get(string id)
        {
            return Json(_budgetService.Get(ConvertToGuid(id)));
        }

        [HttpGet]
        [Route("GetByOperator")]
        public JsonResult GetByOperator(string operatorId)
        {
            return Json(_budgetService.GetByOperatorId(operatorId));
        }

        [Route("UploadBudget")]
        [HttpPost]
        public JsonResult UploadBudget(string id, IFormFile file)
        {

            var fileName = string.Concat("Uploads", "\\", Helpers.RandomString(10), ".csv");

            using (FileStream fs = System.IO.File.Create(fileName))
            {
                file.CopyTo(fs);
                fs.Flush();
                fs.Dispose();
            }
            BackgroundJob.Enqueue(() => _budgetService.UploadBudget(fileName, ConvertToGuid(id)));

            return Json("File Uploaded"); //null just to make error free
        }

        [Route("UploadActual")]
        [HttpPost]
        public JsonResult UploadActual(string id, IFormFile file)
        {

            var fileName = string.Concat("Uploads", "\\", Helpers.RandomString(10), ".csv");

            using (FileStream fs = System.IO.File.Create(fileName))
            {
                file.CopyTo(fs);
                fs.Flush();
                fs.Dispose();
            }
            BackgroundJob.Enqueue(() => _budgetService.UploadActual(fileName, ConvertToGuid(id)));

            return Json("File Uploaded"); //null just to make error free
        }
    }
}

