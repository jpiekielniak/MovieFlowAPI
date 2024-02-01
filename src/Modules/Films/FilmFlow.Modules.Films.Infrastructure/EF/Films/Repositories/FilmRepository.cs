using FilmFlow.Modules.Films.Core.Films.Entities;
using FilmFlow.Modules.Films.Core.Films.Repositories;
using FilmFlow.Modules.Films.Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace FilmFlow.Modules.Films.Infrastructure.EF.Films.Repositories;

internal sealed class FilmRepository(FilmsWriteDbContext dbContext) : IFilmRepository
{
    private readonly DbSet<Film> _films = dbContext.Films;

    public async Task AddAsync(Film film, CancellationToken cancellationToken)
    {
        await _films.AddAsync(film, cancellationToken);
        await CommitAsync(cancellationToken);
    }

    public async Task<bool> FilmExistsAsync(string title, int releaseYear, CancellationToken cancellationToken)
        => await _films.AnyAsync(x => x.Title == title && x.ReleaseYear == releaseYear, cancellationToken);   

    public async Task CommitAsync(CancellationToken cancellationToken)
    => await dbContext.SaveChangesAsync(cancellationToken);
}