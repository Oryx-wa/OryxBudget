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
using OryxBudgetService.OperatorsServices;
using OryxWebApi.ViewModels.OperatorsViewModels;
using Entities.Operators;

namespace OryxWebApi.Controllers.OperatorsControllers
{
    public class OperatorController : BaseController
    {
        private readonly OperatorService _operatorService;

        public OperatorController(OperatorService operatorService)
        {
            _operatorService = operatorService;
        }

        // POST api/values
        [HttpPost]
        [ValidateModelState]
        [Route("Add")]
        public JsonResult Add([FromBody] OperatorViewModel OperatorVm)
        {

            var operato = Mapper.Map<Operator>(OperatorVm);
            _operatorService.Add(operato);
            _operatorService.SaveChanges();
            return Json(_operatorService.Get(operato.Id));

        }

        [HttpPost]
        [ValidateModelState]
        [Route("Update")]
        public JsonResult Update([FromBody]OperatorViewModel OperatorVm)
        {
            var operato = Mapper.Map<Operator>(OperatorVm);
            _operatorService.Update(operato);
            _operatorService.SaveChanges();
            return Json(_operatorService.Get(operato.Id));
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
            return Json(_operatorService.GetAll());
        }


        [HttpGet]
        [Route("GetById")]
        public JsonResult Get(string id)
        {
            return Json(_operatorService.Get(ConvertToGuid(id)));
        }
    }
}
