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
        private BudgetService _budgetService;

        public OperatorController(OperatorService operatorService, BudgetService budgetService)
        {
            _operatorService = operatorService;
            _budgetService = budgetService;
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
            var ops = _operatorService.GetAll();
            IList<dynamic> ret = new List<dynamic>();
            foreach (var op in ops)
            {
                var budget = _budgetService.GetByOperatorId(op.Id.ToString()).FirstOrDefault();
                decimal totalbudget = 0;
                decimal totalActual = 0;
                if (budget != null)
                {
                    totalbudget = budget.TotalBudgetAmount;
                    totalActual = budget.TotalAmountUSD;
                }
                var cm = new
                {
                    Id = op.Id,
                    Name = op.Name,
                    Code = op.Code,
                    ImageSrc = op.ImageSrc,
                    TotalBudget = totalbudget,
                    TotalActual = totalActual
                };

                ret.Add(cm);


            }

            return Json(ret);
        }


        [HttpGet]
        [Route("GetById")]
        public JsonResult Get(string id)
        {
            var op = _operatorService.Get(ConvertToGuid(id));
            var budget = _budgetService.GetByOperatorId(id).FirstOrDefault();

            var ret = Json(new
            {
                Id = op.Id,
                Name = op.Name,
                Code = op.Code,
                ImageSrc = op.ImageSrc,
                TotalBudget = budget.TotalBudgetAmount,
                TotalActual = budget.TotalAmountUSD
            });

            return ret;
        }

        [HttpGet]
        [Route("Lookup")]
        public JsonResult Lookup()
        {
            var op = _operatorService.GetAll()
           .Select(o => new
           {
               Id = o.Id,
               name = o.Name
           }).ToList();           

            return  Json(op);
        }

    }
}
