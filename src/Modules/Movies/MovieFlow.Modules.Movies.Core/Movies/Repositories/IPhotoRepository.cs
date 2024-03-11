using MovieFlow.Modules.Movies.Core.Movies.Entities;

namespace MovieFlow.Modules.Movies.Core.Movies.Repositories;

internal interface IPhotoRepository
{
    Task AddAsync(Photo photo, CancellationToken cancellationToken);
}