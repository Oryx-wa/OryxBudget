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
    public class PeriodController : BaseController
    {
        private readonly PeriodService _periodService;

        public PeriodController(PeriodService periodService)
        {
            _periodService = periodService;
        }

        // POST api/values
        [HttpPost]
        [ValidateModelState]
        [Route("Add")]
        public JsonResult Add([FromBody] PeriodViewModel PeriodVm)
        {

            var period = Mapper.Map<Period>(PeriodVm);
            _periodService.Add(period);
            _periodService.SaveChanges();
            return Json(_periodService.Get(period.Id));

        }

        [HttpPost]
        [ValidateModelState]
        [Route("Update")]
        public JsonResult Update([FromBody]PeriodViewModel PeriodVm)
        {
            var period = Mapper.Map<Period>(PeriodVm);
            _periodService.Update(period);
            _periodService.SaveChanges();
            return Json(_periodService.Get(period.Id));
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
            return Json(_periodService.GetAll());
        }


        [HttpGet]
        [Route("GetById")]
        public JsonResult Get(string id)
        {
            return Json(_periodService.Get(ConvertToGuid(id)));
        }
    }
}
