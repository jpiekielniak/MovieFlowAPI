using Microsoft.Extensions.DependencyInjection;
using MovieFlow.Modules.Newsletters.Core.Newsletters.Repositories;
using MovieFlow.Modules.Newsletters.Infrastructure.EF.Context;
using MovieFlow.Modules.Newsletters.Infrastructure.EF.EmailSubscriptions.Repositories;
using MovieFlow.Shared.Infrastructure.Postgres;

namespace MovieFlow.Modules.Newsletters.Infrastructure.EF;

internal static class DataAccessModule
{
    internal static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services
            .AddPostgres<NewslettersWriteDbContext>();

        services
            .AddScoped<IEmailSubscriptionsRepository, EmailSubscriptionRepository>();

        return services;
    }
}