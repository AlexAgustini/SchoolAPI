using System.Net;

namespace SchoolAPI.Modules.Core.Exceptions;

public class ForbiddenException : CustomHttpException
{
    public ForbiddenException(string message = "Access forbidden"): base(HttpStatusCode.Forbidden, message)
    {
        System.Diagnostics.Debug.WriteLine(message);
    } 
}
;