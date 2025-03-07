using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Persistence.LibraryDb;

public static class LibraryDbContextRegistration
{
    public static void RegisterLibraryDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("LibraryDb");

        services.AddDbContext<LibraryDbContext>(options =>
        {
            options.UseNpgsql(
                connectionString,
                npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsHistoryTable(
                        LibraryDbContext.LibraryMigrationHistory,
                        LibraryDbContext.LibraryDbSchema);
                });
        });
    }
}
