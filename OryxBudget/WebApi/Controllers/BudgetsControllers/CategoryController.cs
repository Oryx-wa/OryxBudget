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
    public class CategoryController : BaseController
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // POST api/values
        [HttpPost][ ValidateModelState]
        [Route("Add")]
        public JsonResult Add([FromBody] CategoryViewModel CategoryVm)
        {

            var category = Mapper.Map<Category>(CategoryVm);
            _categoryService.Add(category);
            _categoryService.SaveChanges();
            return Json(_categoryService.Get(category.Id));

        }

        [HttpPost][ ValidateModelState]
        [Route("Update")]
        public JsonResult Update([FromBody]CategoryViewModel CategoryVm)
        {
            var category = Mapper.Map<Category>(CategoryVm);
            _categoryService.Update(category);
            _categoryService.SaveChanges();
            return Json(_categoryService.Get(category.Id));
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
            return Json(_categoryService.GetAll());
        }


        [HttpGet]
        [Route("GetById")]
        public JsonResult Get(string id)
        {
            return Json(_categoryService.Get(ConvertToGuid(id)));
        }
    }
}

