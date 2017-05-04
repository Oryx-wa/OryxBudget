using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Entities.Budgets;
using OryxBudgetService.BudgetsServices;
using OryxWebapi.Utilities.ActionFilters;
using OryxWebApi.ViewModels.BudgetsViewModels;
using OryxBudgetService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OryxWebApi.Controllers.BudgetsControllers
{
    public class BudgetLineCategoryController : BaseController
    {
        private readonly BudgetLineCategoryService _budgetLineCategoryService;

        public BudgetLineCategoryController(BudgetLineCategoryService budgetLineCategoryService)
        {
            _budgetLineCategoryService = budgetLineCategoryService;
        }

        // POST api/values
        [HttpPost][ ValidateModelState]
        [Route("Add")]
        public JsonResult Add([FromBody] BudgetLineCategoryViewModel BudgetLineCategoryVm)
        {

            var budgetLineCategory = Mapper.Map<BudgetLineCategory>(BudgetLineCategoryVm);
            _budgetLineCategoryService.Add(budgetLineCategory);
            _budgetLineCategoryService.SaveChanges();
            return Json(_budgetLineCategoryService.Get(budgetLineCategory.Id));

        }

        [HttpPost][ ValidateModelState]
        [Route("Update")]
        public JsonResult Update([FromBody]BudgetLineCategoryViewModel BudgetLineCategoryVm)
        {
            var budgetLineCategory = Mapper.Map<BudgetLineCategory>(BudgetLineCategoryVm);
            _budgetLineCategoryService.Update(budgetLineCategory);
            _budgetLineCategoryService.SaveChanges();
            return Json(_budgetLineCategoryService.Get(budgetLineCategory.Id));
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
            return Json(_budgetLineCategoryService.GetAll());
        }


        [HttpGet]
        [Route("GetById")]
        public JsonResult Get(string id)
        {
            return Json(_budgetLineCategoryService.Get(ConvertToGuid(id)));
        }
    }
}

