namespace MovieFlow.Modules.Users.Application.Users.Queries.DTO;

internal record UserDetailsDto(
    Guid UserId,
    string Name,
    string Email,
    bool EmailConfirmed,
    DateTimeOffset? EmailConfirmedAt,
    DateTimeOffset? LastChangePasswordAt,
    string Role,
    bool IsActive);