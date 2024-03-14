using MovieFlow.Modules.Movies.AzureStorage.Events.Events.PhotoDeleted;
using MovieFlow.Modules.Movies.AzureStorage.Services;

namespace MovieFlow.Modules.Movies.AzureStorage.Events.Handlers.PhotoDeleted;

internal sealed class PhotoDeletedEventHandler(IAzureStorageService azureStorageService)
    : INotificationHandler<PhotoDeletedEvent>
{
    public async Task Handle(PhotoDeletedEvent @event, CancellationToken cancellationToken)
    => await azureStorageService.DeleteImageAsync(@event.FileName);
}