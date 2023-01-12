using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sat.Recruitment.Core.DTOs;
using Sat.Recruitment.Core.Enums;
using System.Linq;

#pragma warning disable CS1591 // Disable documentation for this file.

namespace Sat.Recruitment.Api.ErrorHandling
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var auxiliar = context.ModelState.Values.SelectMany(x => x.Errors.Select(y => $"{y.ErrorMessage}."));

                var errorInfo = string.Join(' ', auxiliar.ToList());

                context.Result = new BadRequestObjectResult(
                    new ErrorResponseDTO(ApplicationErrors.InvalidInput, errorInfo));
            }
        }
        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
