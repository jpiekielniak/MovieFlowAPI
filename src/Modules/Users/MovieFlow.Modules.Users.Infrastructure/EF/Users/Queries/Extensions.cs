using MovieFlow.Modules.Users.Application.Users.Queries.DTO;
using MovieFlow.Modules.Users.Infrastructure.EF.Users.Configurations.Read.Model;

namespace MovieFlow.Modules.Users.Infrastructure.EF.Users.Queries;

internal static class Extensions
{
    public static UserDetailsDto AsDetailsDto(this UserReadModel user)
        => new(
            user.Id,
            user.Name,
            user.Email,
            user.EmailConfirmed,
            user.EmailConfirmedAt,
            user.LastChangePasswordAt,
            user.Role.Name,
            user.IsActive
        );
}