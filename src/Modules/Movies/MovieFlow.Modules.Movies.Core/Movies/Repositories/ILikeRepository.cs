using MovieFlow.Modules.Movies.Core.Movies.Entities;

namespace MovieFlow.Modules.Movies.Core.Movies.Repositories;

internal interface ILikeRepository
{
    Task AddAsync(Like like, CancellationToken cancellationToken);
    Task CommitAsync(CancellationToken cancellationToken);
}