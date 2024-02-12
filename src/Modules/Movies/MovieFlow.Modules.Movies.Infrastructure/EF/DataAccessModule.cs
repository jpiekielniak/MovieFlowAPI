using MovieFlow.Modules.Movies.Infrastructure.EF.Context;
using MovieFlow.Shared.Infrastructure.Postgres;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.DataInitializer;
using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Repositories;
using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Services;
using MovieFlow.Shared.Infrastructure;

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
            .AddScoped<IGenreRepository, GenreRepository>()
            .AddScoped<IDirectorRepository, DirectorRepository>();

        services
            .AddScoped<IMovieService, MovieService>();

        services
            .AddInitializer<GenreInitializer>()
            .AddInitializer<DirectorInitializer>()
            .AddInitializer<MovieInitializer>();

        return services;
    }
}