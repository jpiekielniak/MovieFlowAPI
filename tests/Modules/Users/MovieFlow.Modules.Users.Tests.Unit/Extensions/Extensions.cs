using MovieFlow.Modules.Users.Core.Users.Entities;

namespace MovieFlow.Modules.Users.Tests.Unit.Extensions;

internal static class Extensions
{
    public static User CreateUser()
        => User.Create("User123", "example@email.com", "Password123",
            new Role { Id = Guid.NewGuid(), Name = "User", Permissions = [] });

    public static Role CreateRole() => new();
}