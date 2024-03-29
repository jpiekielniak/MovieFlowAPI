using MovieFlow.Modules.Movies.Core.Movies.Entities;

namespace MovieFlow.Modules.Movies.Core.Movies.Repositories;

internal interface IDirectorRepository
{
    Task<Director> GetAsync(Guid id, CancellationToken cancellationToken);
    Task AddAsync(Director director, CancellationToken cancellationToken);
    Task CommitAsync(CancellationToken cancellationToken);
    Task DeleteAsync(Director director, CancellationToken cancellationToken);
}