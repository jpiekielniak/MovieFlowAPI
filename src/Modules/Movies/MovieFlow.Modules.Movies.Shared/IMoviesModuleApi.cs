using MovieFlow.Modules.Movies.Shared.DTO;

namespace MovieFlow.Modules.Movies.Shared;

public interface IMoviesModuleApi
{
    Task<List<ReviewUserDto>> GetReviewsForUserAsync(Guid userId, CancellationToken cancellationToken);
}