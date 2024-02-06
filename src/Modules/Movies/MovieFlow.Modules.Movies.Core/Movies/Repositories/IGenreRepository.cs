using MovieFlow.Modules.Movies.Core.Movies.Entities;

namespace MovieFlow.Modules.Movies.Core.Movies.Repositories;

internal interface IGenreRepository
{
    Task<Genre?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}