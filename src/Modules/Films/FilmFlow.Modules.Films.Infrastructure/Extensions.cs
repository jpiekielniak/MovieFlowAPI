using System.Reflection;
using System.Runtime.CompilerServices;
using FilmFlow.Modules.Films.Infrastructure.EF;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("FilmFlow.Modules.Films.Api")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace FilmFlow.Modules.Films.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        
        services.AddDataAccess();

        return services;
    }
}