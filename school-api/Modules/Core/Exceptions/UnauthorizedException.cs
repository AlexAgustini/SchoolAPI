using System.Net;

namespace school;

public class UnauthorizedException() : CustomHttpException(HttpStatusCode.Unauthorized, "Unauthorized");