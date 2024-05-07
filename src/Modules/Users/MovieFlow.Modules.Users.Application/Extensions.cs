using MovieFlow.Shared.Infrastructure.Validation;

[assembly: InternalsVisibleTo("MovieFlow.Modules.Users.Api")]
[assembly: InternalsVisibleTo("MovieFlow.Modules.Users.Infrastructure")]
[assembly: InternalsVisibleTo("MovieFlow.Modules.Users.Tests.Unit")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace MovieFlow.Modules.Users.Application;

internal static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        services.AddValidators(Assembly.GetExecutingAssembly());
        
        return services;
    }
}