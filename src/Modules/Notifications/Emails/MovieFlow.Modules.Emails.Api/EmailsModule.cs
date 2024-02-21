using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MovieFlow.Modules.Emails.Application;
using MovieFlow.Modules.Emails.Core;
using MovieFlow.Modules.Emails.Infrastructure;
using MovieFlow.Modules.Emails.SendGrid;

namespace MovieFlow.Modules.Emails.Api;

public static class EmailsModule
{
    public static IServiceCollection RegisterEmails(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        services.AddCore();
        services.AddApplication();
        services.AddInfrastructure();
        services.AddSendGrid();

        return services;
    }
}