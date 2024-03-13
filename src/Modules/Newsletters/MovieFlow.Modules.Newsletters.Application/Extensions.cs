using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("MovieFlow.Modules.Newsletters.Api")]
[assembly: InternalsVisibleTo("MovieFlow.Modules.Newsletters.Infrastructure")]

namespace MovieFlow.Modules.Newsletters.Application;

internal static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        
        return services;
    }
}