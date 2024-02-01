using FilmFlow.Modules.Films.Infrastructure.EF.Context;
using FilmFlow.Shared.Infrastructure.Postgres;
using Microsoft.Extensions.DependencyInjection;

namespace FilmFlow.Modules.Films.Infrastructure.EF;

internal static class DataAccessModule
{
    internal static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services
            .AddPostgres<FilmsWriteDbContext>();
        
        return services;
    }
}