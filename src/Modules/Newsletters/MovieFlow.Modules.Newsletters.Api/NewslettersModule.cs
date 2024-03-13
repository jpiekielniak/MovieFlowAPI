using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MovieFlow.Modules.Newsletters.Application;
using MovieFlow.Modules.Newsletters.Core;
using MovieFlow.Modules.Newsletters.Infrastructure;

namespace MovieFlow.Modules.Newsletters.Api;

public static class NewslettersModule
{
    public static IServiceCollection RegisterNewsletters(this IServiceCollection services)
    {
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        services.AddApplication();
        services.AddCore();
        services.AddInfrastructure();
        
        return services;
    }
}