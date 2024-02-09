using Microsoft.Extensions.DependencyInjection;
using MovieFlow.Modules.Users.Infrastructure.EF.Context;
using MovieFlow.Shared.Infrastructure.Postgres;

namespace MovieFlow.Modules.Users.Infrastructure.EF;

internal static class DataAccessModule
{
    internal static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services
            .AddPostgres<UsersWriteDbContext>();
        
        return services;
    }
}