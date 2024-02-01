using MovieFlow.Modules.Movies.Core.Movies.Entities;

namespace MovieFlow.Modules.Movies.Core.Movies.Repositories;

internal interface IMovieRepository
{
    Task AddAsync(Movie movie, CancellationToken cancellationToken);
    Task<bool> MovieExistsAsync(string title, int releaseYear, CancellationToken cancellationToken);
    Task CommitAsync(CancellationToken cancellationToken);
}