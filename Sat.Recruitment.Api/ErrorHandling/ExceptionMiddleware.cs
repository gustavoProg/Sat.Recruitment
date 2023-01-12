using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Sat.Recruitment.Core.DTOs;
using Sat.Recruitment.Core.Enums;
using Sat.Recruitment.Core.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.ErrorHandling
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (CustomApplicationException ex)
            {
                await HandleExceptionAsync(
                    httpContext,
                    HttpStatusCode.BadRequest,
                    ex.ErrorCode,
                    ex.Message);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(
                    httpContext,
                    HttpStatusCode.InternalServerError,
                    ApplicationErrors.Unexpected,
                    $"Unexpected Error: {ex.Message}");
            }
        }



        private async Task HandleExceptionAsync(
            HttpContext context, HttpStatusCode statusCode, ApplicationErrors code, string message)
        {
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = (int)statusCode;

            await context.Response.WriteAsync(
                JsonConvert.SerializeObject(
                    new ErrorResponseDTO(code, message),
                    new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    }));
        }
    }
}
