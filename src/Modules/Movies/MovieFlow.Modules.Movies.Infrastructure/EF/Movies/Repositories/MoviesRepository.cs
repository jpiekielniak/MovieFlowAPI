using Microsoft.EntityFrameworkCore;
using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Repositories;

internal sealed class MovieRepository(MoviesWriteDbContext dbContext) : IMovieRepository
{
    private readonly DbSet<Movie> _Movies = dbContext.Movies;

    public async Task AddAsync(Movie Movie, CancellationToken cancellationToken)
    {
        await _Movies.AddAsync(Movie, cancellationToken);
        await CommitAsync(cancellationToken);
    }

    public async Task<bool> MovieExistsAsync(string title, int releaseYear, CancellationToken cancellationToken)
        => await _Movies.AnyAsync(x => x.Title == title && x.ReleaseYear == releaseYear, cancellationToken);   

    public async Task CommitAsync(CancellationToken cancellationToken)
    => await dbContext.SaveChangesAsync(cancellationToken);
}