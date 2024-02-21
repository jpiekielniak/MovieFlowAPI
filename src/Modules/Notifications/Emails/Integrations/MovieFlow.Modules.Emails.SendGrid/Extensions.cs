using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using MovieFlow.Modules.Emails.Core.Emails.Services;
using MovieFlow.Modules.Emails.SendGrid.Configuration;
using MovieFlow.Modules.Emails.SendGrid.Services;

[assembly: InternalsVisibleTo("MovieFlow.Modules.Emails.Api")]
[assembly: InternalsVisibleTo("MovieFlow.Modules.Emails.Core")]

namespace MovieFlow.Modules.Emails.SendGrid;

internal static class Extensions
{
    public static IServiceCollection AddSendGrid(this IServiceCollection services)
    {
        services.AddSingleton<ISendGridConfiguration, SendGridConfiguration>();
        services.AddSingleton<IEmailService, SendGridService>();
        
        return services;
    }
}