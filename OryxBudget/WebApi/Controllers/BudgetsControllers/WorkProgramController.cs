using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OryxBudgetService.BudgetsServices;
using OryxWebApi.ViewModels.BudgetsViewModels;
using OryxWebapi.Utilities.ActionFilters;
using AutoMapper;
using Entities.Budgets.WorkPrograms;

namespace OryxWebApi.Controllers.BudgetsControllers
{
    public class WorkProgramController : BaseController
    {
        private readonly WorkProgramService _workProgramService;
        private readonly BudgetService _budgetService;

        public WorkProgramController(WorkProgramService workProgramService, BudgetService budgetService)
        {
            _workProgramService = workProgramService;
            _budgetService = budgetService;
        }

        [HttpPost]
        [ValidateModelState]
        [Route("AddWorkProgramStatus")]
        public JsonResult AddWorkProgramStatus([FromBody] WorkProgramStatusViewModel statusVm)
        {
            var status = Mapper.Map<WorkProgramStatus>(statusVm);

           var ret = _workProgramService.AddWorkProgramStatus(statusVm.Department, statusVm.BudgetStatus, statusVm.BudgetId, "");
            _workProgramService.SaveChanges();
            return Json(ret);
        }

        [HttpGet]
        public JsonResult GetWorkProgramStatuses()
        {
            return Json(_workProgramService.GetAllWorkProgramStatuses());
        }

        [HttpGet]
        [Route("GetWorkProgramStatusesByBudget")]
        public JsonResult GetWorkProgramStatusesByBudgetId(string budgetId)
        {
            var ret = _budgetService.GetWorkProgramStatusesByBudget(budgetId);
            return Json(new WorkProgramStatusViewModel(ret));
        }

        [HttpGet]
        [Route("GetAllStatusForBudget")]
        public JsonResult GetAllStatusForBudget(string budgetId)
        {
            var ret = _workProgramService.GetAllStatusForBudget(budgetId);
            IList < WorkProgramStatusViewModel > statuses = new List<WorkProgramStatusViewModel>();
            foreach (var item in ret)
            {
                statuses.Add(new WorkProgramStatusViewModel(item));
            }

            return Json(statuses);
        }

        [HttpGet]
        [Route("GetProgramStatusesById")]
        public JsonResult GetProgramStatusesById(string id)
        {
            var ret = _workProgramService.GetWorkProgramStatusesById(new Guid(id));
            return Json(new WorkProgramStatusViewModel(ret));
        }

        [HttpPost]
        [ValidateModelState]
        [Route("AddDrillingCost")]
        public JsonResult AddDrillingCost([FromBody] DrillingCostViewModel drillingCostVm)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ValidateModelState]
        [Route("UpdateDrillingCost")]
        public JsonResult UpdateDrillingCost([FromBody] DrillingCostViewModel drillingCostVm)
        {
            throw new NotImplementedException();
        }

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
            return Json(_workProgramService.GetAll());
        }

        [HttpGet]
        [Route("GetById")]
        public JsonResult Get(string id)
        {
            return Json(_workProgramService.Get(ConvertToGuid(id)));
        }
    }
}
