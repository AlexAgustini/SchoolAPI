using System.Net;

public class CustomHttpException : Exception
{
    public HttpStatusCode StatusCode { get; }
    
    public CustomHttpException(HttpStatusCode statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }
}