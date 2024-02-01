using FilmFlow.Modules.Films.Core.Films.Entities;

namespace FilmFlow.Modules.Films.Core.Films.Repositories;

internal interface IFilmRepository
{
    Task AddAsync(Film film, CancellationToken cancellationToken);
    Task<bool> FilmExistsAsync(string title, int releaseYear, CancellationToken cancellationToken);
    Task CommitAsync(CancellationToken cancellationToken);
}