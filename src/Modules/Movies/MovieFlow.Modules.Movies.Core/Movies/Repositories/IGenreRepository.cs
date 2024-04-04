using MovieFlow.Modules.Movies.Core.Movies.Entities;

namespace MovieFlow.Modules.Movies.Core.Movies.Repositories;

internal interface IGenreRepository
{
    Task<Genre> GetAsync(Guid genreId, CancellationToken cancellationToken);
    Task<List<Genre>> GetByIdsAsync(List<Guid> genreIds, CancellationToken cancellationToken);
    Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken);
    Task AddAsync(Genre genre, CancellationToken cancellationToken);
    Task DeleteAsync(Genre genre, CancellationToken cancellationToken);
}