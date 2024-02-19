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

        services.AddTransient<IMoviesModuleApi, MoviesModuleApi>();

        return services;
    }
}