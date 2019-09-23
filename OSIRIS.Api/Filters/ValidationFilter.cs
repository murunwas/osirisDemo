using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OSIRIS.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSIRIS.Api.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var errorResponse = new ErrorResponse();
            try
            {
                if (!context.ModelState.IsValid)
                {
                    var errorsInModelState = context.ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage))
                        .ToArray();

                    

                    foreach (var error in errorsInModelState)
                    {
                        foreach (var subError in error.Value)
                        {
                            var errorModel = new ErrorModel
                            {
                                FieldName = error.Key,
                                Message = subError
                            };

                            errorResponse.Errors.Add(errorModel);
                        }
                    }

                    context.Result = new BadRequestObjectResult(errorResponse);
                    return;
                }

                await next();
            }
            catch (Exception e)
            {
                errorResponse.Errors.Add(new ErrorModel { FieldName="Internal Server Error", Message=e.Message });
                context.Result = new BadRequestObjectResult(errorResponse);
            }
        }
    }
}
