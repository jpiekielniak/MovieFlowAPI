using MovieFlow.Modules.Users.Application;
using MovieFlow.Modules.Users.Core;
using MovieFlow.Modules.Users.Infrastructure;

namespace MovieFlow.Modules.Users.Api;

public static class UsersModule
{
    public static IServiceCollection RegisterUsers(this IServiceCollection services)
    {
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        services.AddApplication();
        services.AddCore();
        services.AddInfrastructure();
        
        return services;
    }
}