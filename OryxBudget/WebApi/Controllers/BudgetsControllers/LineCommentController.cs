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

namespace OryxBudgetService.Controllers.BudgetsControllers
{
    public class LineCommentController : BaseController
    {
        private readonly LineCommentService _lineCommentService;

        public LineCommentController(LineCommentService lineCommentService)
        {
            _lineCommentService = lineCommentService;
        }

        // POST api/values
        [HttpPost]
        [ValidateModelState]
        [Route("Add")]
        public JsonResult Add([FromBody] LineCommentViewModel LineCommentVm)
        {

            var lineComment = Mapper.Map<LineComment>(LineCommentVm);
            _lineCommentService.Add(lineComment);
            _lineCommentService.SaveChanges();
            return Json(_lineCommentService.Get(lineComment.Id));

        }

        [HttpPost]
        [ValidateModelState]
        [Route("Update")]
        public JsonResult Update([FromBody]LineCommentViewModel LineCommentVm)
        {
            var lineComment = Mapper.Map<LineComment>(LineCommentVm);
            _lineCommentService.Update(lineComment);
            _lineCommentService.SaveChanges();
            return Json(_lineCommentService.Get(lineComment.Id));
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
            return Json(_lineCommentService.GetAll());
        }


        [HttpGet]
        [Route("GetById")]
        public JsonResult Get(string id)
        {
            return Json(_lineCommentService.Get(ConvertToGuid(id)));
        }
    }
}
