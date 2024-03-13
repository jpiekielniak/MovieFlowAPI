namespace MovieFlow.Modules.Emails.Shared.Events.Newsletters.EmailSubscriptions.SubscribeEmailNewsletter;

public record SubscribedEmailNewsletterEvent(string Email, DateTimeOffset JoinedAt) : INotification;