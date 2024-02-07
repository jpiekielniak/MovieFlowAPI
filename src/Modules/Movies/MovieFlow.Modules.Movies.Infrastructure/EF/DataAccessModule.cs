using MovieFlow.Modules.Movies.Infrastructure.EF.Context;
using MovieFlow.Shared.Infrastructure.Postgres;
using Microsoft.Extensions.DependencyInjection;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Repositories;
using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Services;

namespace MovieFlow.Modules.Movies.Infrastructure.EF;

internal static class DataAccessModule
{
    internal static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services
            .AddPostgres<MoviesWriteDbContext>()
            .AddPostgres<MoviesReadDbContext>();

        services
            .AddScoped<IMovieRepository, MovieRepository>()
            .AddScoped<IGenreRepository, GenreRepository>();

        services
            .AddScoped<IMovieService, MovieService>();
        
        return services;
    }
}