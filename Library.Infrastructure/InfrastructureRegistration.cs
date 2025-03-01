using Library.Core.Common.DbContext;
using Library.Core.Domain.Authors.Common;
using Library.Core.Domain.Books.Common;
using Library.Infrastructure.Core.Common;
using Library.Infrastructure.Core.Domain;
using Library.Infrastructure.Middleware.ExceptionHandler;
using Library.Infrastructure.Middleware.Response;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Library.Infrastructure;

public static class InfrastructureRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IBooksRepository, BooksRepository>();
        services.AddScoped<IAuthorsRepository, AuthorsRepository>();

        services.AddSingleton<IExceptionToResponseMapper, ExceptionToResponseMapper>();
        services.AddTransient<ExceptionHandlerMiddleware>();
    }
}