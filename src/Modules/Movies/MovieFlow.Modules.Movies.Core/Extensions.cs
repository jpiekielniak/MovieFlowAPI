[assembly: InternalsVisibleTo("MovieFlow.Modules.Movies.Api")]
[assembly: InternalsVisibleTo("MovieFlow.Modules.Movies.Application")]
[assembly: InternalsVisibleTo("MovieFlow.Modules.Movies.Infrastructure")]
[assembly: InternalsVisibleTo("MovieFlow.Modules.Movies.Tests.Unit")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace MovieFlow.Modules.Movies.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return services;
    }
}