using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using MovieFlow.Modules.Newsletters.Infrastructure.EF;

[assembly: InternalsVisibleTo("MovieFlow.Modules.Newsletters.Api")]

namespace MovieFlow.Modules.Newsletters.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        services.AddDataAccess();

        return services;
    }
}