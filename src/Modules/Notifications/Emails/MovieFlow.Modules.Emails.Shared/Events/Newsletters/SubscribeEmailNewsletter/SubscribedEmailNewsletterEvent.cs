namespace MovieFlow.Modules.Emails.Shared.Events.Newsletters.SubscribeEmailNewsletter;

public record SubscribedEmailNewsletterEvent(string Email, DateTimeOffset JoinedAt) : INotification;