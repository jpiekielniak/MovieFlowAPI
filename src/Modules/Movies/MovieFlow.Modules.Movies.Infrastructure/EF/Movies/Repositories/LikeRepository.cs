using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Repositories;

internal sealed class LikeRepository(MoviesWriteDbContext dbContext) : ILikeRepository
{
    private readonly DbSet<Like> _likes = dbContext.Likes;

    public async Task AddAsync(Like like, CancellationToken cancellationToken)
    {
        await _likes.AddAsync(like, cancellationToken);
        await CommitAsync(cancellationToken);
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
        => await dbContext.SaveChangesAsync(cancellationToken);
}