using MovieFlow.Modules.Emails.Core.Emails.Repositories;
using MovieFlow.Modules.Emails.Infrastructure.EF.Contexts;
using MovieFlow.Modules.Emails.Infrastructure.EF.Emails.Repositories;
using MovieFlow.Shared.Infrastructure.Postgres;

namespace MovieFlow.Modules.Emails.Infrastructure.EF;

internal static class DataAccessModule
{
    internal static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services
            .AddPostgres<EmailsWriteDbContext>();

        services
            .AddScoped<IEmailRepository, EmailRepository>();

        return services;
    }
}