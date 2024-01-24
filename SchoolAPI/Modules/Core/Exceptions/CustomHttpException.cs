using System.Net;

namespace SchoolAPI.Modules.Core.Exceptions;
public class CustomHttpException : Exception
{
    public HttpStatusCode StatusCode { get; }
    
    public CustomHttpException(HttpStatusCode statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }
}