namespace MovieFlow.Modules.Emails.Shared.Events.Newsletters.EmailSubscriptions.CreatedMovie;

public record CreatedMovieEmailSubscriptionEvent(string Title, string Description, string ImageUrl, IEnumerable<string> Emails) : INotification;