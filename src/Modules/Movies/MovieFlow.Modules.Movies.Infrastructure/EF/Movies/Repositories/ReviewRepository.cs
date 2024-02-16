using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Repositories;

internal sealed class ReviewRepository(MoviesWriteDbContext dbContext) : IReviewRepository
{
    private readonly DbSet<Review> _reviews = dbContext.Reviews;

    public async Task AddAsync(Review review, CancellationToken cancellationToken)
    {
        await _reviews.AddAsync(review, cancellationToken);
        await CommitAsync(cancellationToken);
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
        => await dbContext.SaveChangesAsync(cancellationToken);

    public async Task<Review> GetAsync(Guid reviewId, CancellationToken cancellationToken)
        => await _reviews.Include(x => x.Likes).SingleOrDefaultAsync(x => x.Id == reviewId, cancellationToken);

    public async Task UpdateAsync(Review review, CancellationToken cancellationToken)
    {
        _reviews.Update(review);
        await CommitAsync(cancellationToken);
    }
}