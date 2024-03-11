using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Repositories;

internal sealed class PhotoRepository(MoviesWriteDbContext writeDbContext) : IPhotoRepository
{
    private readonly DbSet<Photo> _photos = writeDbContext.Photos;

    public async Task AddAsync(Photo photo, CancellationToken cancellationToken)
    {
        await _photos.AddAsync(photo, cancellationToken);
        await writeDbContext.SaveChangesAsync(cancellationToken);
    }
}