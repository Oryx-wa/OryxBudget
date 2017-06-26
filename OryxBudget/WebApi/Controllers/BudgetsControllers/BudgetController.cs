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
using OryxBudgetService.Utilities.SignalRHubs;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using Microsoft.Net.Http.Headers;
using OryxSecurity.Services;

namespace OryxWebApi.Controllers.BudgetControllers
{
    public class BudgetController : BaseController
    {
        private readonly BudgetService _budgetService;
        private readonly BudgetLineService _lineService;
        private readonly PeriodService _periodService;
        private readonly BackgroundJobClient _jobs = new BackgroundJobClient();
        protected IUserResolverService _userResolverService;

        public BudgetController(BudgetService budgetService, BudgetLineService lineService, PeriodService periodService,
            IConnectionManager signalRConnectionManager, IUserResolverService userResolverService)
             : base()
        {
            _budgetService = budgetService;
            _lineService = lineService;
            _periodService = periodService;
            _userResolverService = userResolverService;
        }

        // POST api/values
        [HttpPost]
        [ValidateModelState]
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
        public JsonResult AddLineComment(string budgetId, string code, string type, string status, [FromBody] CombinedLineViewModel vm)
        {

            if (vm.LineComments != null)
            {
                var lineComment = Mapper.Map<IEnumerable<LineComment>>(vm.LineComments);
                _budgetService.AddLineComments(lineComment); 
            }
            if (vm.BudgetLine != null)
            {
                var budgetLine = Mapper.Map<BudgetLine>(vm.BudgetLine);
                _lineService.UpdateNapimsReview(type, budgetLine, code);
            }

            if (!string.IsNullOrEmpty(status))
            {
                //var status = vm.StatusHistory;
                _budgetService.updateStatus(status, code, budgetId);
            }


            _budgetService.SaveChanges();
            return Json(_budgetService.GetLineComment(budgetId, code));

        }



        [HttpPost]
        [ValidateModelState]
        [Route("AddComment")]
        public JsonResult AddComment( [FromBody] LineCommentViewModel vm)
        {

            var lineComment = Mapper.Map<LineComment>(vm);
            IList<LineComment> comments = new List<LineComment>();
            comments.Add(lineComment);
            _budgetService.AddLineComments(comments);

            _budgetService.SaveChanges();
            return Json("Ok");

        }

        [HttpPost]
        [ValidateModelState]
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
        public JsonResult GetOperatorBudgetDetails(string id)
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
            var ret = _budgetService.GetLineComment(budgetId, code);
            return Json(ret);
        }
        [HttpGet]
        [Route("GetLineStatus")]
        public JsonResult GetLineStatus(string budgetId, string code)
        {
            var dbStatus = _budgetService.GetLineStatus(budgetId, code);
            IList<StatusHistoryViewModel> ret = new List<StatusHistoryViewModel>();
            foreach (var item in dbStatus)
            {
                ret.Add(new StatusHistoryViewModel(item));
            }             
            return Json(ret);
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

            var x = _jobs.Enqueue(() => _budgetService.UploadBudget(fileName, ConvertToGuid(id),
                _userResolverService.GetUser()));
            //BackgroundJob.Enqueue(() => _budgetService.UploadBudget(fileName, ConvertToGuid(id)));

            return Json("File Uploaded"); //null just to make error free
        }

        [Route("InitializeBudgetForAllOperators")]
        [HttpPost]
        public JsonResult InitializeBudgetForAllOperators(int year, string description)
        {
            string periodId = _periodService.GetAll().Where(p => p.StartDate.Year == year).FirstOrDefault().Id.ToString();
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
                    BudgetId = this.ConvertToGuid(budgetId),
                    BudgetLineId = this.ConvertToGuid(budgetlineId)
                };

                _budgetService.AddAttachment(attachment);
            }

            _budgetService.SaveChanges();

            return Json("File(s) Uploaded!"); //null just to make error free
        }

        [Route("DownloadAttachment")]
        [HttpGet]
        public ActionResult DownloadAttachment(string id)
        {
            var fileEntity = _budgetService.GetAttachment(new Guid(id));
            if (fileEntity != null)
                File(fileEntity.FileData, fileEntity.FileType);

            return Json("File Downloaded!");
        }
    }
}

