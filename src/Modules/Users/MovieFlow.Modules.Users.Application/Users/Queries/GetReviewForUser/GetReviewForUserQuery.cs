using MovieFlow.Modules.Movies.Shared.DTO;

namespace MovieFlow.Modules.Users.Application.Users.Queries.GetReviewForUser;

internal record GetReviewForUserQuery(Guid userId) : IRequest<List<ReviewUserDto>>;