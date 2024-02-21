using MovieFlow.Modules.Emails.Infrastructure.EF;

[assembly: InternalsVisibleTo("MovieFlow.Modules.Emails.Api")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace MovieFlow.Modules.Emails.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services.AddDataAccess();
    }
}
