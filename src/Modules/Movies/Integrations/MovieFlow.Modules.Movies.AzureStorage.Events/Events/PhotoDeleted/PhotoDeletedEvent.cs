using MediatR;

namespace MovieFlow.Modules.Movies.AzureStorage.Events.Events.PhotoDeleted;

public record PhotoDeletedEvent(string FileName) : INotification;