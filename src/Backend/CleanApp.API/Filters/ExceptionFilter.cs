using CleanApp.Communication.Responses;
using CleanApp.Exception;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanApp.API.Filters;
public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is CleanAppException)
        {
            HandleAppException(context);
        }
        else
        {
            ThrowUnknowException(context);
        }
    }

    private void HandleAppException(ExceptionContext context)
    {
        if (context.Exception is ErrorOnValidationException)
        {
            var ex = context.Exception as ErrorOnValidationException;

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new ObjectResult(new ResponseErrorJson(ex.ErrorMessages));
        }
    }
    private void ThrowUnknowException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorJson(ResourceExceptionMessages.UNKNOW_ERROR));
    }
}
