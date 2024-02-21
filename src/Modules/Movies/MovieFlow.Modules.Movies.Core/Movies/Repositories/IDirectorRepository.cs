using MovieFlow.Modules.Movies.Core.Movies.Entities;

namespace MovieFlow.Modules.Movies.Core.Movies.Repositories;

internal interface IDirectorRepository
{
    Task<Director> GetAsync(Guid id, CancellationToken cancellationToken);
}