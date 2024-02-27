using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Repositories;

internal class GenreRepository(MoviesWriteDbContext dbContext) : IGenreRepository
{
    private readonly DbSet<Genre> _genres = dbContext.Genres;

    public async Task<Genre> GetAsync(Guid genreId, CancellationToken cancellationToken)
        => await _genres.SingleOrDefaultAsync(x => x.Id == genreId, cancellationToken);

    public async Task<List<Genre>> GetByIdsAsync(List<Guid> genreIds,
        CancellationToken cancellationToken)
        => await _genres
            .Where(g => genreIds.Contains(g.Id))
            .ToListAsync(cancellationToken);

    public async Task<bool> ExistsByNameAsync(string name,
        CancellationToken cancellationToken)
        => await _genres.AnyAsync(g => g.Name == name, cancellationToken);

    public async Task AddAsync(Genre genre, CancellationToken cancellationToken)
    {
        await _genres.AddAsync(genre, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Genre genre, CancellationToken cancellationToken)
    {
        _genres.Remove(genre);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}