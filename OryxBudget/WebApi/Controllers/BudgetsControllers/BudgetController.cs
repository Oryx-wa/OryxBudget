using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Entities.Budgets;
using OryxBudgetService.BudgetsServices;
using OryxWebapi.Utilities.ActionFilters;
using OryxBudgetService.ViewModels.BudgetsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OryxWebapi.Utilities;
using System.IO;
using Hangfire;
using OryxBudgetService.Utilities.SignalRHubs;
using Microsoft.AspNetCore.SignalR.Infrastructure;

namespace OryxBudgetService.Controllers.BudgetControllers
{
    public class BudgetController :  ApiHubController<NotificationHub>
    {
        private readonly BudgetService _budgetService;
        private readonly BudgetLineService _lineService;
        private readonly PeriodService _periodService;
        private readonly BackgroundJobClient _jobs = new BackgroundJobClient();

        public BudgetController(BudgetService budgetService, BudgetLineService lineService,  PeriodService periodService,
            IConnectionManager signalRConnectionManager)
             : base(signalRConnectionManager)
        {
            _budgetService = budgetService;
            _lineService = lineService;
            _periodService = periodService;
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

        [HttpPost]
        [ValidateModelState]
        [Route("AddLineComment")]
        public JsonResult AddLineComment(string budgetId, string code, string type,[FromBody] CombinedLineViewModel vm)
        {

            var lineComment = Mapper.Map<IEnumerable<LineComment>>(vm.LineComments);
            _budgetService.AddLineComments(lineComment);

            var budgetLine = Mapper.Map<BudgetLine>(vm.BudgetLine);
            _lineService.UpdateNapimsReview(type, budgetLine, code);
            _budgetService.SaveChanges();
            return Json(_budgetService.GetLineComment(budgetId, code));

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
        [Route("GetOperatorBudgetDetails")]
        public  JsonResult GetOperatorBudgetDetails(string id)
        {
            return Json(_budgetService.GetOperatorBudget(id));
        }

        [HttpGet]
        [Route("GetBudgetDetails")]
        public JsonResult GetBudgetDetails(string id)
        {
            var ret = _budgetService.GetBudgetDetails(id);
            return Json(ret);
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

        [HttpGet]
        [Route("GetLineComment")]
        public JsonResult GetLineComment(string budgetId, string code)
        {
            return Json(_budgetService.GetLineComment(budgetId, code));
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
            var x = _jobs.Enqueue(() => _budgetService.UploadBudget(fileName, ConvertToGuid(id)));
            //BackgroundJob.Enqueue(() => _budgetService.UploadBudget(fileName, ConvertToGuid(id)));

            return Json("File Uploaded"); //null just to make error free
        }

        [Route("InitializeBudgetForAllOperators")]
        [HttpPost]
        public JsonResult InitializeBudgetForAllOperators(int year, string description)
        {
            string periodId =_periodService.GetAll().Where(p => p.StartDate.Year == year).FirstOrDefault().Id.ToString();
            BackgroundJob.Enqueue(() => _budgetService.InitializeBudgetForAllOperators(periodId, description));
            return Json("Budget initialized for all operators");
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

