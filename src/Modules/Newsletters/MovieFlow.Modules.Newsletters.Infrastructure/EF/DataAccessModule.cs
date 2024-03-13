using Microsoft.Extensions.DependencyInjection;
using MovieFlow.Modules.Newsletters.Infrastructure.EF.Context;
using MovieFlow.Shared.Infrastructure.Postgres;

namespace MovieFlow.Modules.Newsletters.Infrastructure.EF;

internal static class DataAccessModule
{
    internal static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services
            .AddPostgres<NewslettersWriteDbContext>();

        return services;
    }
}