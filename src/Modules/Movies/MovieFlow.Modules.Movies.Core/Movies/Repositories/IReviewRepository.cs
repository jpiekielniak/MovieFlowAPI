using MovieFlow.Modules.Movies.Core.Movies.Entities;

namespace MovieFlow.Modules.Movies.Core.Movies.Repositories;

internal interface IReviewRepository
{
    Task AddAsync(Review review, CancellationToken cancellationToken);
    Task CommitAsync(CancellationToken cancellationToken);
    Task<Review> GetAsync(Guid reviewId, CancellationToken cancellationToken);
    Task DeleteAsync(Review review, CancellationToken cancellationToken);
    Task<List<Review>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
}