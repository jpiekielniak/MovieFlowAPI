using MovieFlow.Modules.Movies.Application.Directors.Commands.CreateDirector;
using MovieFlow.Modules.Movies.Application.Genres.Commands.CreateGenre;
using MovieFlow.Modules.Movies.Application.Movies.Commands.ChangeMovieInformation;
using MovieFlow.Modules.Movies.Application.Reviews.Commands.AddReview;
using MovieFlow.Modules.Movies.Application.Reviews.Commands.ChangeReviewInformation;
using MovieFlow.Modules.Movies.Application.Services;
using MovieFlow.Modules.Movies.Shared;

[assembly: InternalsVisibleTo("MovieFlow.Modules.Movies.Api")]
[assembly: InternalsVisibleTo("MovieFlow.Modules.Movies.Infrastructure")]

namespace MovieFlow.Modules.Movies.Application;

internal static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        services
            .AddScoped<IValidator<CreateGenreCommand>, CreateGenreValidator>()
            .AddScoped<IValidator<CreateGenreCommand>, CreateGenreValidator>()
            .AddScoped<IValidator<ChangeMovieInformationCommand>, ChangeMovieInformationValidator>()
            .AddScoped<IValidator<AddReviewCommand>, AddReviewValidator>()
            .AddScoped<IValidator<ChangeReviewInformationCommand>, ChangeReviewInformationValidator>()
            .AddScoped<IValidator<CreateDirectorCommand>, CreateDirectorValidator>();

        services.AddTransient<IMoviesModuleApi, MoviesModuleApi>();

        return services;
    }
}