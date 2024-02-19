using MovieFlow.Modules.Users.Application.Users.Queries.DTO;

namespace MovieFlow.Modules.Users.Application.Users.Queries.Get;

internal record GetUserQuery(Guid userId) : IRequest<UserDetailsDto?>;