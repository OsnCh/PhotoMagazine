using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PhotoMagazine.ViewModels.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PhotoMagazine.Api.Filters
{
    public class ModelStateValidatorFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new OkObjectResult(new ResponseViewModel
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = GetErrors(context.ModelState),
                    Result = false
                }); 
            }

        }

        private string GetErrors(ModelStateDictionary modelState)
        {
            string messages = string.Join(",",modelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage));
            return messages;
        }
    }
}
