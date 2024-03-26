using MovieFlow.Modules.Movies.Infrastructure.EF.Context;
using MovieFlow.Shared.Infrastructure.Postgres;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Modules.Movies.Infrastructure.EF.Directors.Services;
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
            .AddScoped<IGenreRepository, GenreRepository>()
            .AddScoped<IDirectorRepository, DirectorRepository>()
            .AddScoped<IReviewRepository, ReviewRepository>()
            .AddScoped<ILikeRepository, LikeRepository>()
            .AddScoped<IPhotoRepository, PhotoRepository>();

        services
            .AddScoped<IMovieService, MovieService>()
            .AddScoped<IDirectorService, DirectorService>();

        /*services
            .AddInitializer<GenreInitializer>()
            .AddInitializer<DirectorInitializer>()
            .AddInitializer<MovieInitializer>();*/

        return services;
    }
}