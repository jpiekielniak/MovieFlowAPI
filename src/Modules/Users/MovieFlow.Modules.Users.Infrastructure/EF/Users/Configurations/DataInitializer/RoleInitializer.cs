using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieFlow.Modules.Users.Core.Entities;
using MovieFlow.Modules.Users.Infrastructure.EF.Context;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Name;
using MovieFlow.Shared.Infrastructure;

namespace MovieFlow.Modules.Users.Infrastructure.EF.Users.Configurations.DataInitializer;

internal sealed class RoleInitializer(
    UsersWriteDbContext writeDbContext,
    ILogger<UsersWriteDbContext> logger) : IInitializer
{
    private readonly HashSet<string> _adminPermissions = ["Genres", "Movies", "Users"];

    private readonly HashSet<string> _userPermissions = ["Movies", "Users", "Genres"];

    public async Task InitDataAsync()
    {
        if (await writeDbContext.Roles.AnyAsync()) return;
        await writeDbContext.Roles.AddAsync(new Role
        {
            Id = Guid.NewGuid(),
            Name = new Name("Admin"),
            Permissions = _adminPermissions
        });

        await writeDbContext.Roles.AddAsync(new Role
        {
            Id = Guid.NewGuid(),
            Name = new Name("User"),
            Permissions = _userPermissions
        });

        await writeDbContext.SaveChangesAsync();
        logger.Log(LogLevel.Information, "Role data initialized");
    }
}