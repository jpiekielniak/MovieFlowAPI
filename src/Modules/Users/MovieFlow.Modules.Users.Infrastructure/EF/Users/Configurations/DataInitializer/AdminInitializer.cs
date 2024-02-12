using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieFlow.Modules.Users.Core.Entities;
using MovieFlow.Modules.Users.Core.Exceptions;
using MovieFlow.Modules.Users.Infrastructure.EF.Context;
using MovieFlow.Shared.Infrastructure;

namespace MovieFlow.Modules.Users.Infrastructure.EF.Users.Configurations.DataInitializer;

internal sealed class AdminInitializer(
    UsersWriteDbContext writeDbContext,
    ILogger<UsersWriteDbContext> logger, 
    IPasswordHasher<User> passwordHasher) : IInitializer
{
    private const string AdminEmail = "admin@movieflow.com";
    private const string AdminPassword = "admin123";
    private const string AdminRole = "Admin";

    public async Task InitDataAsync()
    {
        if (!await writeDbContext.Users.AnyAsync(x => x.Email == AdminEmail))
        {
            var role = await writeDbContext.Roles.SingleOrDefaultAsync(x => x.Name == AdminRole);

            if (role is null)
                throw new RoleNotFoundException(AdminRole);

            var password = passwordHasher.HashPassword(default, AdminPassword);
            var admin = User.Create(AdminEmail, password, role);

            await writeDbContext.AddAsync(admin);
            await writeDbContext.SaveChangesAsync();
            logger.Log(LogLevel.Information, "Admin initialized");
        }
    }
}