using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MovieFlow.Modules.Users.Core.Entities;
using MovieFlow.Modules.Users.Infrastructure.EF.Context;
using MovieFlow.Modules.Users.Infrastructure.EF.Users.Configurations.DataInitializer;
using MovieFlow.Shared.Infrastructure;
using MovieFlow.Shared.Infrastructure.Postgres;

namespace MovieFlow.Modules.Users.Infrastructure.EF;

internal static class DataAccessModule
{
    internal static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services
            .AddPostgres<UsersWriteDbContext>();
        
        services
            .AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();

        services
            .AddInitializer<RoleInitializer>()
            .AddInitializer<AdminInitializer>();
        
        return services;
    }
}