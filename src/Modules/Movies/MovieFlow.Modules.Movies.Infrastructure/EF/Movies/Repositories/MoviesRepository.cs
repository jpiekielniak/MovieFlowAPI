using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Repositories;

internal sealed class MovieRepository(MoviesWriteDbContext dbContext) : IMovieRepository
{
    private readonly DbSet<Movie> _movies = dbContext.Movies;

    public async Task AddAsync(Movie movie, CancellationToken cancellationToken)
    {
        await _movies.AddAsync(movie, cancellationToken);
        await CommitAsync(cancellationToken);
    }

    public async Task<bool> MovieExistsAsync(string title, int releaseYear, CancellationToken cancellationToken)
        => await _movies.AnyAsync(x => x.Title == title && x.ReleaseYear == releaseYear,
            cancellationToken);

    public async Task<Movie> GetAsync(Guid id, CancellationToken cancellationToken)
        => await _movies
            .Include(x => x.Genres)
            .Include(x => x.Director)
            .Include(x => x.Reviews)
            .Include(x => x.Photos)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task CommitAsync(CancellationToken cancellationToken)
        => await dbContext.SaveChangesAsync(cancellationToken);

    public async Task DeleteAsync(Movie movie, CancellationToken cancellationToken)
    {
        _movies.Remove(movie);
        await CommitAsync(cancellationToken);
    }

    public async Task UpdateAsync(Movie movie, CancellationToken cancellationToken)
    {
        _movies.Update(movie);
        await CommitAsync(cancellationToken);
    }
}