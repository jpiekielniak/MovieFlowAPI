using MovieFlow.Modules.Movies.Application.Services.Extensions;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Modules.Movies.Shared;
using MovieFlow.Modules.Movies.Shared.DTO;

namespace MovieFlow.Modules.Movies.Application.Services;

internal sealed class MoviesModuleApi(IReviewRepository reviewRepository) : IMoviesModuleApi
{
    public async Task<List<ReviewUserDto>> GetReviewsForUserAsync(Guid userId,
        CancellationToken cancellationToken)
    {
        var reviews = await reviewRepository.GetByUserIdAsync(userId, cancellationToken);

        return reviews
            .Select(x => x.AsDto())
            .ToList();
    }
}