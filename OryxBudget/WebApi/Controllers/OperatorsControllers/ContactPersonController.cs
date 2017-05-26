using AutoMapper;
using Entities.Operators;
using Microsoft.AspNetCore.Mvc;
using OryxBudgetService.OperatorsServices;
using OryxWebapi.Utilities.ActionFilters;
using OryxWebApi.ViewModels.OperatorsViewModels;


namespace OryxWebApi.Controllers.OperatorsControllers
{
    public class ContactPersonController : BaseController
    {
        private readonly ContactPersonService _contactPersonsService;

        public ContactPersonController(ContactPersonService contactPersonService)
        {
            _contactPersonsService = contactPersonService;
        }

        // POST api/values
        [HttpPost]
        [ValidateModelState]
        [Route("Add")]
        public JsonResult Add([FromBody] ContactPersonViewModel ContactPersonsVm)
        {

            var contactPersons = Mapper.Map<ContactPerson>(ContactPersonsVm);
            _contactPersonsService.Add(contactPersons);
            _contactPersonsService.SaveChanges();
            return Json(_contactPersonsService.Get(contactPersons.Id));

        }

        [HttpPost]
        [ValidateModelState]
        [Route("Update")]
        public JsonResult Update([FromBody]ContactPersonViewModel ContactPersonsVm)
        {
            var contactPerson = Mapper.Map<ContactPerson>(ContactPersonsVm);
            _contactPersonsService.Update(contactPerson);
            _contactPersonsService.SaveChanges();
            return Json(_contactPersonsService.Get(contactPerson.Id));
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
            return Json(_contactPersonsService.GetAll());
        }


        [HttpGet]
        [Route("GetById")]
        public JsonResult Get(string id)
        {
            return Json(_contactPersonsService.Get(ConvertToGuid(id)));
        }
    }
}
