using MovieFlow.Shared.Infrastructure.Validation;

[assembly: InternalsVisibleTo("MovieFlow.Modules.Newsletters.Api")]
[assembly: InternalsVisibleTo("MovieFlow.Modules.Newsletters.Infrastructure")]
[assembly: InternalsVisibleTo("MovieFlow.Modules.Newsletters.Tests.Unit")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace MovieFlow.Modules.Newsletters.Application;

internal static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        services.AddValidators(Assembly.GetExecutingAssembly());

        return services;
    }
}