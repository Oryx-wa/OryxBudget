using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OryxWebapi.Utilities.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OryxBudgetService.OperatorsServices;
using OryxWebApi.ViewModels.OperatorsViewModels;
using Entities.Operators;

namespace OryxWebApi.Controllers.OperatorsControllers
{
    public class OperatorTypeController : BaseController
    {
        private readonly OperatorTypeService _operatorTypeService;

        public OperatorTypeController(OperatorTypeService operatorTypeService)
        {
            _operatorTypeService = operatorTypeService;
        }

        // POST api/values
        [HttpPost]
        [ValidateModelState]
        [Route("Add")]
        public JsonResult Add([FromBody] OperatorTypeViewModel OperatorTypeVm)
        {

            var operatorType = Mapper.Map<OperatorType>(OperatorTypeVm);
            _operatorTypeService.Add(operatorType);
            _operatorTypeService.SaveChanges();
            return Json(_operatorTypeService.Get(operatorType.Id));

        }

        [HttpPost]
        [ValidateModelState]
        [Route("Update")]
        public JsonResult Update([FromBody]OperatorTypeViewModel OperatorTypeVm)
        {
            var operatorType = Mapper.Map<OperatorType>(OperatorTypeVm);
            _operatorTypeService.Update(operatorType);
            _operatorTypeService.SaveChanges();
            return Json(_operatorTypeService.Get(operatorType.Id));
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
            return Json(_operatorTypeService.GetAll());
        }


        [HttpGet]
        [Route("GetById")]
        public JsonResult Get(string id)
        {
            return Json(_operatorTypeService.Get(ConvertToGuid(id)));
        }
    }
}
