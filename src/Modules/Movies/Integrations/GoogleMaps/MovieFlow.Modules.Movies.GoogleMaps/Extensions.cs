using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using MovieFlow.Modules.Movies.GoogleMaps.Configuration;
using MovieFlow.Modules.Movies.GoogleMaps.Services;

[assembly: InternalsVisibleTo("MovieFlow.Modules.Movies.Api")]
namespace MovieFlow.Modules.Movies.GoogleMaps;

internal static class Extensions
{
    public static IServiceCollection AddGoogleMaps(this IServiceCollection services)
    {
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        
        services.AddSingleton<IGoogleMapsConfiguration, GoogleMapsConfiguration>();
        services.AddSingleton<IGoogleMapsService, GoogleMapsService>();
        
        return services;
    }
}