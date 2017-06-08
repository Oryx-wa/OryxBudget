using OryxBudgetService.OperatorsServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OryxWebApi.ViewModels.OperatorsViewModels;
using AutoMapper;
using Entities.Operators;
using OryxWebapi.Utilities.ActionFilters;

namespace OryxWebApi.Controllers.OperatorsControllers
{
    public class WellController : BaseController
    {
        private readonly WellService _wellService;

        public WellController(WellService wellService)
        {
            _wellService = wellService;
        }

        [HttpPost]
        [ValidateModelState]
        [Route("Add")]
        public JsonResult Add([FromBody] WellViewModel wellVm)
        {
            var well = Mapper.Map<Well>(wellVm);
            _wellService.Add(well);
            _wellService.SaveChanges();
            return Json(_wellService.Get(well.Id));
        }

        [HttpPost]
        [ValidateModelState]
        [Route("Update")]
        public JsonResult Update([FromBody] WellViewModel wellVm)
        {
            var well = Mapper.Map<Well>(wellVm);
            _wellService.Update(well);
            _wellService.SaveChanges();
            return Json(_wellService.Get(well.Id));
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
            return Json(_wellService.GetAll());
        }

        [HttpGet]
        [Route("GetById")]
        public JsonResult Get(string id)
        {
            return Json(_wellService.Get(ConvertToGuid(id)));
        }
    }
}
