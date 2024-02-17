namespace MovieFlow.Modules.Users.Application.Users.Queries.DTO;

internal record UserDetailsDto(
    Guid UserId,
    string Name,
    string Email,
    string Role,
    bool IsActive);