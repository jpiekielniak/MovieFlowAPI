﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MovieFlow.Shared.Infrastructure.Postgres;

public static class Extensions
{
    internal static IServiceCollection AddPostgres(this IServiceCollection services)
    {
        var options = services.GetOptions<PostgresOptions>("postgres");
        services.AddSingleton(options);

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


        return services;
    }

    public static IServiceCollection AddPostgres<T>(this IServiceCollection services) where T : DbContext
    {
        var options = services.GetOptions<PostgresOptions>("postgres");

        services.AddDbContext<T>(x => x.UseNpgsql(options.ConnectionString));

        return services;
    }
}