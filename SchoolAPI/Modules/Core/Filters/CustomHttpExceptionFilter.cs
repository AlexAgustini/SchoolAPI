using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;
using SchoolAPI.Modules.Core.Exceptions;

namespace SchoolAPI.Modules.Core.Filters;

public class CustomHttpExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        switch (context.Exception)
        {
            case CustomHttpException customException:
                context.Result = new ObjectResult(new
                {
                    StatusCode = (int)customException.StatusCode,
                    Message = customException.Message
                })  {StatusCode = (int) customException.StatusCode};
                context.ExceptionHandled = true;
                break;
            case SqlException:
                context.Result = new ObjectResult(new
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message =  "Database error"
                })  {StatusCode = (int) HttpStatusCode.InternalServerError};
                break;
            default:
                System.Diagnostics.Debug.WriteLine("LAST QUERY");
                System.Diagnostics.Debug.WriteLine(context.Exception);
            
                context.Result = new ObjectResult(new
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message =  "Internal server error"
                }) {StatusCode = (int) HttpStatusCode.InternalServerError};
                break;
        }
    }
}