using MovieFlow.Modules.Users.Core.Users.Entities;
using MovieFlow.Modules.Users.Core.Users.Repositories;
using MovieFlow.Modules.Users.Infrastructure.EF.Context;
using MovieFlow.Modules.Users.Infrastructure.EF.Users.Configurations.DataInitializer;
using MovieFlow.Modules.Users.Infrastructure.EF.Users.Repositories;
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
            .AddScoped<IRoleRepository, RoleRepository>()
            .AddScoped<IUserRepository, UserRepository>();
        
        services
            .AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();

        services
            .AddInitializer<RoleInitializer>()
            .AddInitializer<AdminInitializer>();
        
        return services;
    }
}