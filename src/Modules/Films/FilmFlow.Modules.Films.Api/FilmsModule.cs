using System.Reflection;
using FilmFlow.Modules.Films.Application;
using FilmFlow.Modules.Films.Core;
using FilmFlow.Modules.Films.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace FilmFlow.Modules.Films.Api;

public static class FilmsModule
{
    public static IServiceCollection RegisterFilms(this IServiceCollection services)
    {
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));    

        services.AddCore();
        services.AddApplication();
        services.AddInfrastructure();
        
        return services;
    }
}