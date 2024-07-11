using Journey.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Journey.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is NotFoundException)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            context.Result = new NotFoundObjectResult(context.Exception.Message);
        }
    }
}