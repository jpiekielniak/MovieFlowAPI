using MovieFlow.Modules.Movies.Core.Movies.Entities;

namespace MovieFlow.Modules.Movies.Core.Movies.Repositories;

internal interface IPhotoRepository
{
    Task AddAsync(Photo photo, CancellationToken cancellationToken);
    Task<Photo> GetAsync(Guid photoId, CancellationToken cancellationToken);
    Task DeleteAsync(Photo photo, CancellationToken cancellationToken);
}