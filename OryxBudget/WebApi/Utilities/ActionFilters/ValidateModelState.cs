using OryxWebapi.Utilities.ErrorHandling;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OryxWebapi.Utilities.ActionFilters
{
    public class ValidateModelState : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.SelectMany(x => x.Value.Errors);
                ValidationErrorCollection retErrors = new ValidationErrorCollection();
                foreach (var item in errors)
                {
                    if (item.Exception != null)
                    {
                        retErrors.Add(item.Exception.Message);
                    }
                    else
                    {
                        retErrors.Add(item.ErrorMessage);
                    }
                   
                }
                //var output = new Result() { Status = Status.Error.ToString(), Data = null, Message = arr };
                //hrow new ApiException("Model State Error", (int)HttpStatusCode.BadRequest, retErrors);
                context.Result = new BadRequestObjectResult(new JsonResult(retErrors.ToString()));
            }
        }
    }
}
