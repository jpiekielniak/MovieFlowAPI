using MovieFlow.Modules.Movies.Shared;
using MovieFlow.Modules.Movies.Shared.DTO;
using MovieFlow.Modules.Users.Application.Users.Queries.GetReviewForUser;
using MovieFlow.Modules.Users.Core.Users.Exceptions;
using MovieFlow.Modules.Users.Core.Users.Exceptions.Users;
using MovieFlow.Modules.Users.Infrastructure.EF.Context;
using MovieFlow.Shared.Abstractions;

namespace MovieFlow.Modules.Users.Infrastructure.EF.Users.Queries.GetReviewForUser;

internal sealed class GetReviewForUserHandler(
    UsersReadDbContext readDbContext,
    IMoviesModuleApi moviesModuleApi) : IRequestHandler<GetReviewForUserQuery, List<ReviewUserDto>>
{
    public async Task<List<ReviewUserDto>> Handle(GetReviewForUserQuery query,
        CancellationToken cancellationToken)
    {
        var user = await readDbContext.Users
            .SingleOrDefaultAsync(x => x.Id == query.userId, cancellationToken)
            .NotNull(() => new UserNotFoundException(query.userId));

        var userReviews = await moviesModuleApi
            .GetReviewsForUserAsync(user.Id, cancellationToken);

        return userReviews;
    }
}