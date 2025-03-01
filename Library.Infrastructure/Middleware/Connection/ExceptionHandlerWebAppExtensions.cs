using Library.Infrastructure.Middleware.ExceptionHandler;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Library.Infrastructure.Middleware.Connection;

public static class ExceptionHandlerWebApplicationExtensions
{
    public static void UseCustomExceptionHandler(this IApplicationBuilder app, IWebHostEnvironment environment)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}
