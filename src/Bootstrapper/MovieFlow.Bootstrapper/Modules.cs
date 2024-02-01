using MovieFlow.Modules.Movies.Api;

namespace MovieFlow.Bootstrapper;

public static class Modules
{
    public static IServiceCollection AddModules(this IServiceCollection services)
    {
        services.RegisterMovies();
        
        return services;
    }
}


