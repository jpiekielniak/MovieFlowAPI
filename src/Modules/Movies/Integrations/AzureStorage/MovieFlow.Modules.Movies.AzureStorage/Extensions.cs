using MovieFlow.Modules.Movies.AzureStorage.Configuration;
using MovieFlow.Modules.Movies.AzureStorage.Services;

[assembly: InternalsVisibleTo("MovieFlow.Modules.Movies.Api")]
namespace MovieFlow.Modules.Movies.AzureStorage;

internal static class Extensions
{
    public static IServiceCollection AddAzureStorage(this IServiceCollection services)
    {
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        
        services.AddSingleton<IAzureStorageConfiguration, AzureStorageConfiguration>();
        services.AddSingleton<IAzureStorageService, AzureStorageService>();
        
        return services;
    }
}