using Microsoft.AspNetCore.Mvc.Filters;
using Hackathon.Application.CustomExceptions;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.API.Filters
{
    public class ApplicationExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is BadRequestException)
            {
                var exception = context.Exception as BadRequestException;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new JsonResult(new
                {
                    Message = exception.Message,
                    Errors = exception.Errors
                });
            }

            if (context.Exception is NotAuthorizedException)
            {
                var exception = context.Exception as NotAuthorizedException;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Result = new JsonResult(new
                {
                    Message = exception.Message,
                    Errors = new Dictionary<string, string>()
                });
            }

            if (context.Exception is NotFoundException)
            {
                var exception = context.Exception as NotFoundException;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Result = new JsonResult(new
                {
                    Message = exception.Message,
                    Errors = new Dictionary<string, string>()
                });
            }
        }   
    }
}