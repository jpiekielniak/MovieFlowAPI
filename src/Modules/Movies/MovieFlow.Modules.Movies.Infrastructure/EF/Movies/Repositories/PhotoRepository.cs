using MovieFlow.Modules.Movies.AzureStorage.Events.Events.PhotoDeleted;
using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Repositories;

internal sealed class PhotoRepository(MoviesWriteDbContext writeDbContext,
    IMediator mediator) : IPhotoRepository
{
    private readonly DbSet<Photo> _photos = writeDbContext.Photos;

    public async Task AddAsync(Photo photo, CancellationToken cancellationToken)
    {
        await _photos.AddAsync(photo, cancellationToken);
        await writeDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Photo> GetAsync(Guid photoId, CancellationToken cancellationToken)
        => await _photos.SingleOrDefaultAsync(x => x.Id == photoId, cancellationToken);

    public async Task DeleteAsync(Photo photo, CancellationToken cancellationToken)
    {
        _photos.Remove(photo);
        await writeDbContext.SaveChangesAsync(cancellationToken);
        await mediator.Publish(new PhotoDeletedEvent(photo.FileName), cancellationToken);
    }

    public async Task UpdateAsync(Photo photo, CancellationToken cancellationToken)
    {
        _photos.Update(photo);
        await writeDbContext.SaveChangesAsync(cancellationToken);
    }
}