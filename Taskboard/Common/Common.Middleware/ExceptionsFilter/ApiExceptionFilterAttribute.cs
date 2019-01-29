using Common.DataContracts.Enums;
using Common.DataContracts.Errors;
using Common.Errors;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Common.Middleware.ExceptionsFilter
{
    public class ApiExceptionFilterAttribute: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            Error error;
            string stackTrace = string.Empty;

            var exceptionType = context.Exception.GetType();
            if (exceptionType == typeof(RequestTimeoutException))
            {
                error = ErrorManager.GetById(52);
            }
            else
            {
                error = ErrorManager.GetById(1);
                error.ErrorMessage = context.Exception.GetBaseException().Message;
                stackTrace = context.Exception.GetBaseException().StackTrace;
            }

            context.HttpContext.Response.StatusCode = (int) error.HttpStatusCode;
            context.HttpContext.Response.ContentType = "application/json";

            var err = new
            {
                responseStatus = ResponseStatus.Failed,
                error = new ResponseError(error)
            };

            err.error.StackTrace = stackTrace;

            context.Result = new JsonResult(err);

            base.OnException(context);
        }
    }
}
