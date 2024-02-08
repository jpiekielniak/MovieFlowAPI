using MovieFlow.Modules.Movies.Core.Movies.Entities;

namespace MovieFlow.Modules.Movies.Core.Movies.Repositories;

internal interface IGenreRepository
{
    Task<List<Genre>> GetByIdsAsync(List<Guid> genreIds, CancellationToken cancellationToken);
}