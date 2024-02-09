using MovieFlow.Modules.Movies.Api;
using MovieFlow.Modules.Users.Api;

namespace MovieFlow.Bootstrapper;

public static class Modules
{
    public static IServiceCollection AddModules(this IServiceCollection services)
    {
        services.RegisterMovies();
        services.RegisterUsers();
        
        return services;
    }
}


