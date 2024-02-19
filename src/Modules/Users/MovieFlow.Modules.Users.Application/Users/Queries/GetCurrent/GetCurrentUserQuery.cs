using MovieFlow.Modules.Users.Application.Users.Queries.DTO;

namespace MovieFlow.Modules.Users.Application.Users.Queries.GetCurrent;

internal record GetCurrentUserQuery : IRequest<UserDetailsDto>;