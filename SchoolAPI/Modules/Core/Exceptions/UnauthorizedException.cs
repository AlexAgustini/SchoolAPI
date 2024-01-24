using System.Net;

namespace SchoolAPI.Modules.Core.Exceptions;

public class UnauthorizedException() : CustomHttpException(HttpStatusCode.Unauthorized, "Unauthorized");