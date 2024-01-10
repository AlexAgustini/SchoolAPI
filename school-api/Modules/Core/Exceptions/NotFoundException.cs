using System.Net;

namespace SchoolAPI.Modules.Core.Exceptions;

public class NotFoundException() : CustomHttpException(HttpStatusCode.NotFound, "Register not found");