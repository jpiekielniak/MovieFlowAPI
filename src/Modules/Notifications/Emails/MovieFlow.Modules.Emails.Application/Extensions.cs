using System.Reflection;
using System.Runtime.CompilerServices;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MovieFlow.Modules.Emails.Shared.Events.Users;

[assembly: InternalsVisibleTo("MovieFlow.Modules.Emails.Api")]
[assembly: InternalsVisibleTo("MovieFlow.Modules.Emails.Infrastructure")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace MovieFlow.Modules.Emails.Application;

internal static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        return services;
    }
}