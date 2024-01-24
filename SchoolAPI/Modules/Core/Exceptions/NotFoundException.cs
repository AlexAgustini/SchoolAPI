using System.Net;

namespace SchoolAPI.Modules.Core.Exceptions;

public class NotFoundException : CustomHttpException
{
    public NotFoundException(string message = "Register not found"): base(HttpStatusCode.NotFound, message)
    {
        System.Diagnostics.Debug.WriteLine(message);
    } 
}
;