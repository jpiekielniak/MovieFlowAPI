using MovieFlow.Modules.Movies.Application.Services;
using MovieFlow.Modules.Movies.Shared;
using MovieFlow.Shared.Infrastructure.Validation;

[assembly: InternalsVisibleTo("MovieFlow.Modules.Movies.Api")]
[assembly: InternalsVisibleTo("MovieFlow.Modules.Movies.Infrastructure")]
[assembly: InternalsVisibleTo("MovieFlow.Modules.Movies.Tests.Unit")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace MovieFlow.Modules.Movies.Application;

internal static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        services.AddValidators(Assembly.GetExecutingAssembly());

        services.AddTransient<IMoviesModuleApi, MoviesModuleApi>();

        return services;
    }
}