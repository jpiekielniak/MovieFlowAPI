using MediatR;

namespace MovieFlow.Modules.Newsletters.Shared.Events.CreatedMovie;

public record CreatedMovieEvent(string Title, string Description, string ImageUrl) : INotification;