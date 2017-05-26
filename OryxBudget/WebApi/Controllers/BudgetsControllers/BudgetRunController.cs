using OryxBudgetService.BudgetsServices;
using OryxWebapi.Utilities.ActionFilters;
using OryxWebApi.ViewModels.BudgetsViewModels;
using OryxBudgetService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Entities.Budgets;

namespace OryxWebApi.Controllers.BudgetsControllers
{
    public class BudgetRunController : BaseController
    {
        private readonly BudgetRunService _budgetRunService;

        public BudgetRunController(BudgetRunService budgetRunService)
        {
            _budgetRunService = budgetRunService;
        }

        // POST api/values
        [HttpPost]
        [ValidateModelState]
        [Route("Add")]
        public JsonResult Add([FromBody] BudgetRunViewModel BudgetRunVm)
        {

            var budgetRun = Mapper.Map<BudgetRun>(BudgetRunVm);
            _budgetRunService.Add(budgetRun);
            _budgetRunService.SaveChanges();
            return Json(_budgetRunService.Get(budgetRun.Id));

        }

        [HttpPost]
        [ValidateModelState]
        [Route("Update")]
        public JsonResult Update([FromBody]BudgetRunViewModel BudgetRunVm)
        {
            var budgetRun = Mapper.Map<BudgetRun>(BudgetRunVm);
            _budgetRunService.Update(budgetRun);
            _budgetRunService.SaveChanges();
            return Json(_budgetRunService.Get(budgetRun.Id));
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
            return Json(_budgetRunService.GetAll());
        }


        [HttpGet]
        [Route("GetById")]
        public JsonResult Get(string id)
        {
            return Json(_budgetRunService.Get(ConvertToGuid(id)));
        }
    }
}
