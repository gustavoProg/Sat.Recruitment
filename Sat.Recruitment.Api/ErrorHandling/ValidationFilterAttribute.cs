using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sat.Recruitment.Core.DTOs;
using Sat.Recruitment.Core.Enums;

namespace Sat.Recruitment.Api.ErrorHandling
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(
                    new ErrorResponseDTO(ApplicationErrors.InvalidInput, context.ModelState.ToString()));
            }
        }
        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
