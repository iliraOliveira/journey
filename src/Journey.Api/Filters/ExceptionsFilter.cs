using Journey.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Journey.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.HttpContext is JourneyException)
        {
            context.HttpContext.Response.StatusCode = 
        }
    }
}