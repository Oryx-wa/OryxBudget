using OryxBudgetService.BudgetsServices;
using OryxWebapi.Utilities.ActionFilters;
using OryxWebApi.ViewModels.BudgetsViewModels;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Entities.Budgets;

namespace OryxWebApi.Controllers.BudgetsControllers
{
    public class BudgetCodeController : BaseController
    {
        private readonly BudgetCodeService _budgetCodeService;

        public BudgetCodeController(BudgetCodeService budgetCodeService)
        {
            _budgetCodeService = budgetCodeService;
        }

        // POST api/values
        [HttpPost]
        [ValidateModelState]
        [Route("Add")]
        public JsonResult Add([FromBody] BudgetCodeViewModel BudgetCodesVm)
        {

            var budgetCode = Mapper.Map<BudgetCode>(BudgetCodesVm);
            _budgetCodeService.Add(budgetCode);
            _budgetCodeService.SaveChanges();
            return Json(_budgetCodeService.Get(budgetCode.Id));

        }

        [HttpPost]
        [ValidateModelState]
        [Route("Update")]
        public JsonResult Update([FromBody]BudgetCodeViewModel BudgetCodesVm)
        {
            var budgetCode = Mapper.Map<BudgetCode>(BudgetCodesVm);
            _budgetCodeService.Update(budgetCode);
            _budgetCodeService.SaveChanges();
            return Json(_budgetCodeService.Get(budgetCode.Id));
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
            return Json(_budgetCodeService.GetAll());
        }


        [HttpGet]
        [Route("GetById")]
        public JsonResult Get(string id)
        {
            return Json(_budgetCodeService.Get(ConvertToGuid(id)));
        }
    }
}
