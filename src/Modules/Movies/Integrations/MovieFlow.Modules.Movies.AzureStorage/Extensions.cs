using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using MovieFlow.Modules.Movies.AzureStorage.Configuration;
using MovieFlow.Modules.Movies.AzureStorage.Services;

[assembly: InternalsVisibleTo("MovieFlow.Modules.Movies.Api")]
namespace MovieFlow.Modules.Movies.AzureStorage;

internal static class Extensions
{
    public static IServiceCollection AddAzureStorage(this IServiceCollection services)
    {
        services.AddSingleton<IAzureStorageConfiguration, AzureStorageConfiguration>();
        services.AddSingleton<IAzureStorageService, AzureStorageService>();
        
        return services;
    }
}