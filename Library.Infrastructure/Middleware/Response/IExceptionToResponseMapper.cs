namespace Library.Infrastructure.Middleware.Response;

public interface IExceptionToResponseMapper
{
    ExceptionResponse Map(Exception exception);
}