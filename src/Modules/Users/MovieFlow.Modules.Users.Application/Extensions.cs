
[assembly: InternalsVisibleTo("MovieFlow.Modules.Users.Api")]
[assembly: InternalsVisibleTo("MovieFlow.Modules.Users.Infrastructure")]

namespace MovieFlow.Modules.Users.Application;

internal static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        return services;
    }
}