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
using OryxWebApi.Utilities.SignalRHubs;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using Microsoft.Net.Http.Headers;

namespace OryxWebApi.Controllers.BudgetControllers
{
    public class BudgetController :  ApiHubController<NotificationHub>
    {
        private readonly BudgetService _budgetService;

        public BudgetController(BudgetService budgetService, IConnectionManager signalRConnectionManager)
             : base(signalRConnectionManager)
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

        [HttpPost]
        [ValidateModelState]
        [Route("AddLineComment")]
        public JsonResult AddLineComment(string budgetId, string code,[FromBody] IEnumerable<LineCommentViewModel> vm)
        {

            var lineComment = Mapper.Map<IEnumerable<LineComment>>(vm);
            _budgetService.AddLineComments(lineComment);
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
            BackgroundJob.Enqueue(() => _budgetService.UploadBudget(fileName, ConvertToGuid(id)));

            return Json("File Uploaded"); //null just to make error free
        }

        [Route("InitializeBudgetForAllOperators")]
        [HttpPost]
        public JsonResult InitializeBudgetForAllOperators(string periodId, string description)
        {
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

        [Route("UploadAttachment")]
        [HttpPost]
        public JsonResult UploadAttachment(IFormFile file, string budgetId, string budgetlineId)
        {
            if (file.Length > 0)
            {
                byte[] fileBytes = null;
                var filename = ContentDispositionHeaderValue
                            .Parse(file.ContentDisposition)
                            .FileName
                            .Trim('"');

                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    string contentAsString = reader.ReadToEnd();
                    fileBytes = new byte[contentAsString.Length * sizeof(char)];
                    System.Buffer.BlockCopy(contentAsString.ToCharArray(), 0, fileBytes, 0, fileBytes.Length);
                }

                var attachment = new Attachment
                {
                    FileData = fileBytes,
                    FileName = filename,
                    FileType = file.ContentType,
                    BudgetId = this.ConvertToGuid( budgetId),
                    BudgetLineId = this.ConvertToGuid(budgetlineId)
                };

                _budgetService.AddAttachment(attachment);
            }

            _budgetService.SaveChanges();

            return Json("File(s) Uploaded!"); //null just to make error free
        }

        public ActionResult DownloadAttachment(string id)
        {
            var fileEntity = _budgetService.GetAttachment(new Guid(id));
            if (fileEntity != null)
                File(fileEntity.FileData, fileEntity.FileType);

            return Json("File Downloaded!");
        }
    }
}

