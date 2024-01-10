using System.Net;

namespace school;

public class ForbiddenException() : CustomHttpException(HttpStatusCode.Forbidden, "Access forbidden");