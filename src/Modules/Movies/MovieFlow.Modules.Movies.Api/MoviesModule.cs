using System.Reflection;
using MovieFlow.Modules.Movies.Application;
using MovieFlow.Modules.Movies.Core;
using MovieFlow.Modules.Movies.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace MovieFlow.Modules.Movies.Api;

public static class MoviesModule
{
    public static IServiceCollection RegisterMovies(this IServiceCollection services)
    {
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));    

        services.AddCore();
        services.AddApplication();
        services.AddInfrastructure();
        
        return services;
    }
}