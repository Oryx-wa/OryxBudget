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
    public class ActualsController : BaseController
    {
        private readonly ActualsService _actualsService;

        public ActualsController(ActualsService actualsService)
        {
            _actualsService = actualsService;
        }

        // POST api/values
        [HttpPost]
        [ValidateModelState]
        [Route("Add")]
        public JsonResult Add([FromBody] ActualsViewModel ActualsVm)
        {

            var actuals = Mapper.Map<Actuals>(ActualsVm);
            _actualsService.Add(actuals);
            _actualsService.SaveChanges();
            return Json(_actualsService.Get(actuals.Id));

        }

        [HttpPost]
        [ValidateModelState]
        [Route("Update")]
        public JsonResult Update([FromBody]ActualsViewModel ActualsVm)
        {
            var actuals = Mapper.Map<Actuals>(ActualsVm);
            _actualsService.Update(actuals);
            _actualsService.SaveChanges();
            return Json(_actualsService.Get(actuals.Id));
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
            return Json(_actualsService.GetAll());
        }


        [HttpGet]
        [Route("GetById")]
        public JsonResult Get(string id)
        {
            return Json(_actualsService.Get(ConvertToGuid(id)));
        }
    }
}
