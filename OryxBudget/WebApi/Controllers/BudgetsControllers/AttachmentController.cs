using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OryxBudgetService.BudgetsServices;
using OryxWebapi.Utilities.ActionFilters;
using OryxWebApi.ViewModels.BudgetsViewModels;
using AutoMapper;
using Entities.Budgets;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System.IO;

namespace OryxWebApi.Controllers.BudgetsControllers
{
    public class AttachmentController : BaseController
    {
        private readonly AttachmentService _attachmentService;

        public AttachmentController(AttachmentService attachmentService)
        {
            _attachmentService = attachmentService;
        }

        [HttpGet]
        public override JsonResult Get()
        {
            return Json(_attachmentService.GetAll());
        }

        [HttpPost]
        [ValidateModelState]
        [Route("Add")]
        public JsonResult Add([FromBody] AttachmentViewModel attachmentVm)
        {
            var attachment = Mapper.Map<Attachment>(attachmentVm);
            _attachmentService.Add(attachment);
            _attachmentService.SaveChanges();
            return Json(_attachmentService.Get(attachment.Id));

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

        [Route("UploadAttachment")]
        [HttpPost]
        public JsonResult UploadAttachment([FromBody] AttachmentViewModel attachmentVm, IList<IFormFile> files)
        {
            foreach (var file in files)
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
                        BudgetId = attachmentVm.BudgetId,
                        BudgetLineId = attachmentVm.BudgetLineId
                    };

                    _attachmentService.Add(attachment);
                }
                
            }

            _attachmentService.SaveChanges();

            return Json("File(s) Uploaded!"); //null just to make error free
        }
    }
}
