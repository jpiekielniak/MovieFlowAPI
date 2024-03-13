namespace MovieFlow.Modules.Emails.Shared.Events.Newsletters.EmailSubscriptions.UnSubscribeEmailNewsletter;

public record UnSubscribedEmailNewsletterEvent(string Email, DateTimeOffset UnSubscribedAt) : INotification;