using MovieFlow.Modules.Users.Application.Users.Queries.DTO;

namespace MovieFlow.Modules.Users.Application.Users.Queries.GetCurrentLoggedUser;

internal record GetCurrentLoggedUserQuery : IRequest<UserDetailsDto>;