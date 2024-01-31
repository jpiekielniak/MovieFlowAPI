using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("FilmFlow.Modules.Films.Api")]
[assembly: InternalsVisibleTo("FilmFlow.Modules.Films.Application")]
[assembly: InternalsVisibleTo("FilmFlow.Modules.Films.Infrastructure")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace FilmFlow.Modules.Films.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return services;
    }
}