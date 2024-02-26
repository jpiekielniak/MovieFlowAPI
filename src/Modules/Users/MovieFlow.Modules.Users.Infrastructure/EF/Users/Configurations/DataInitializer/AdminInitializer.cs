using MovieFlow.Modules.Users.Core.Users.Entities;
using MovieFlow.Modules.Users.Core.Users.Exceptions.Roles;
using MovieFlow.Modules.Users.Infrastructure.EF.Context;
using MovieFlow.Shared.Infrastructure;

namespace MovieFlow.Modules.Users.Infrastructure.EF.Users.Configurations.DataInitializer;

internal sealed class AdminInitializer(
    UsersWriteDbContext writeDbContext,
    ILogger<UsersWriteDbContext> logger,
    IPasswordHasher<User> passwordHasher) : IInitializer
{
    private const string Name = "ADMIN";
    private const string Email = "admin@movieflow.com";
    private const string Password = "admin123";
    private const string Role = "Admin";

    public async Task InitDataAsync()
    {
        if (!await AdminExist())
        {
            var role = await writeDbContext.Roles.SingleOrDefaultAsync(x => x.Name == Role);

            if (role is null)
                throw new RoleNotFoundException(Role);

            var password = passwordHasher.HashPassword(default, Password);
            var admin = User.Create(Name, Email, password, role);

            await writeDbContext.AddAsync(admin);
            await writeDbContext.SaveChangesAsync();
            logger.Log(LogLevel.Information, "Admin initialized");
        }
    }

    private async Task<bool> AdminExist()
        => await writeDbContext.Users.AnyAsync(x => x.Email == Email && x.Name == Name);
}