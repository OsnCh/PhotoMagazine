using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PhotoMagazine.ViewModels.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PhotoMagazine.Api.Filters
{
    public class ResponseDataFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult)
            {
                var valueResult = (context.Result as ObjectResult).Value;
                if (valueResult is string)
                {
                    context.Result = new OkObjectResult(new ResponseViewModel
                    {
                        Message = valueResult as string,
                        Result = (context.Result is OkObjectResult) ? true : false,
                        StatusCode = (int)((context.Result is OkObjectResult)?
                            HttpStatusCode.OK:
                            HttpStatusCode.BadRequest)
                    });

                }
                
                if(valueResult is ResponseDataViewModel)
                {
                    var data = valueResult as ResponseDataViewModel;
                    context.Result = new OkObjectResult(new ResponseViewModel
                    {
                        Message = data.Message,
                        Result = true,
                        StatusCode = (int)HttpStatusCode.OK,
                        Data = data.Data
                    });
                }

                return;
            }

        }
    }
}
