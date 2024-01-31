using FilmFlow.Modules.Films.Api;

namespace FilmFlow.Bootstrapper;

public static class Modules
{
    public static IServiceCollection AddModules(this IServiceCollection services)
    {
        services.RegisterFilms();
        
        return services;
    }
}


