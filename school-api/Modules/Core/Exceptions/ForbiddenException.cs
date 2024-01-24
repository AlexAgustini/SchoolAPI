using System.Net;

namespace school;

public class ForbiddenException : CustomHttpException
{
    public ForbiddenException(string message = "Access forbidden"): base(HttpStatusCode.Forbidden, message)
    {
        System.Diagnostics.Debug.WriteLine(message);
    } 
}
;