using System.Net;

namespace Library.Infrastructure.Middleware.Response;

public record ExceptionResponse(HttpStatusCode StatusCode, object Data);