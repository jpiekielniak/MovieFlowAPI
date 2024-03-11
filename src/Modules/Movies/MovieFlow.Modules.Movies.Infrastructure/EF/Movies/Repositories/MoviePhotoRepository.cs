using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Repositories;

internal sealed class MoviePhotoRepository(MoviesWriteDbContext writeDbContext) : IMoviePhotoRepository
{
    private readonly DbSet<MoviePhoto> _moviePhotos = writeDbContext.MoviePhotos;
    
    public async Task AddAsync(MoviePhoto moviePhoto, CancellationToken cancellationToken)
    {
        await _moviePhotos.AddAsync(moviePhoto, cancellationToken);
        await writeDbContext.SaveChangesAsync(cancellationToken);

    }
}