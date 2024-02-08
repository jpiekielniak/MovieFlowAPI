using Microsoft.EntityFrameworkCore;
using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Genres;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;
using MovieFlow.Shared.Abstractions;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Repositories;

internal class GenreRepository(MoviesWriteDbContext dbContext) : IGenreRepository
{
    private readonly DbSet<Genre> _genres = dbContext.Genres;

    public async Task<List<Genre>> GetByIdsAsync(List<Guid> genreIds, CancellationToken cancellationToken)
        => await _genres
            .Where(g => genreIds.Contains(g.Id))
            .ToListAsync(cancellationToken);
}