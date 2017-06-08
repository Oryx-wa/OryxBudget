using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OryxBudgetService.BudgetsServices;
using OryxWebApi.ViewModels.BudgetsViewModels;
using OryxWebapi.Utilities.ActionFilters;

namespace OryxWebApi.Controllers.BudgetsControllers
{
    public class WorkProgramController : BaseController
    {
        private readonly WorkProgramService _workProgramService;
        
        public WorkProgramController(WorkProgramService workProgramService)
        {
            _workProgramService = workProgramService;
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
