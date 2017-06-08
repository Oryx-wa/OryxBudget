using OryxWebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OryxBudgetService.OperatorsServices;
using OryxWebapi.Utilities.ActionFilters;
using OryxWebApi.ViewModels.OperatorsViewModels;
using AutoMapper;
using Entities.Operators;

namespace OryxWebApi.Controllers.OperatorsControllers
{
    public class FieldController : BaseController
    {
        private readonly FieldService _fieldService;

        public FieldController(FieldService fieldService)
        {
            _fieldService = fieldService;
        }

        [HttpPost]
        [ValidateModelState]
        [Route("Add")]
        public JsonResult Add([FromBody] FieldViewModel fieldVm)
        {
            var field = Mapper.Map<Field>(fieldVm);
            _fieldService.Add(field);
            _fieldService.SaveChanges();
            return Json(_fieldService.Get(field.Id));
        }

        [HttpPost]
        [ValidateModelState]
        [Route("Update")]
        public JsonResult Update([FromBody] FieldViewModel fieldVm)
        {
            var field = Mapper.Map<Field>(fieldVm);
            _fieldService.Update(field);
            _fieldService.SaveChanges();
            return Json(_fieldService.Get(field.Id));
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
            return Json(_fieldService.GetAll());
        }

        [HttpGet]
        [Route("GetById")]
        public JsonResult Get(string id)
        {
            return Json(_fieldService.Get(ConvertToGuid(id)));
        }
    }
}
