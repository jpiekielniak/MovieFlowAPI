using MovieFlow.Modules.Movies.Core.Movies.Entities;

namespace MovieFlow.Modules.Movies.Core.Movies.Repositories;

internal interface IGenreRepository
{
    Task<Genre> GetAsync(Guid commandGenreId, CancellationToken cancellationToken);
    Task<List<Genre>> GetByIdsAsync(List<Guid> genreIds, CancellationToken cancellationToken);
    Task<bool> ExistsByNameAsync(string commandName, CancellationToken cancellationToken);
    Task AddAsync(Genre genre, CancellationToken cancellationToken);
    Task DeleteAsync(Genre genre, CancellationToken cancellationToken);
}