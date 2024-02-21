using MovieFlow.Modules.Emails.Infrastructure.EF.Contexts;
using MovieFlow.Shared.Infrastructure.Postgres;

namespace MovieFlow.Modules.Emails.Infrastructure.EF;

internal static class DataAccessModule
{
    internal static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services
            .AddPostgres<EmailsWriteDbContext>();

        return services;
    }
}