using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("FilmFlow.Modules.Films.Api")]
[assembly: InternalsVisibleTo("FilmFlow.Modules.Films.Infrastructure")]

namespace FilmFlow.Modules.Films.Application;

internal static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        return services;
    }
}