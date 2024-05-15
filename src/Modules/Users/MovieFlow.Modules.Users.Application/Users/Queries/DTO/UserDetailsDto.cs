namespace MovieFlow.Modules.Users.Application.Users.Queries.DTO;

internal record UserDetailsDto(
    Guid UserId,
    string Name,
    string Email,
    DateTimeOffset? LastChangePasswordAt,
    string Role,
    bool IsActive);