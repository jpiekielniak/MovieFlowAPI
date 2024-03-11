using MovieFlow.Modules.Movies.Core.Movies.Entities;

namespace MovieFlow.Modules.Movies.Core.Movies.Repositories;

internal interface IMoviePhotoRepository
{
    Task AddAsync(MoviePhoto moviePhoto, CancellationToken cancellationToken);
}