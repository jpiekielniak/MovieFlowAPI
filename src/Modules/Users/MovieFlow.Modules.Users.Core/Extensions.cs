
[assembly: InternalsVisibleTo("MovieFlow.Modules.Users.Api")]
[assembly: InternalsVisibleTo("MovieFlow.Modules.Users.Application")]
[assembly: InternalsVisibleTo("MovieFlow.Modules.Users.Infrastructure")]
[assembly: InternalsVisibleTo("MovieFlow.Modules.Users.Tests.Unit")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace MovieFlow.Modules.Users.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return services;
    }
}