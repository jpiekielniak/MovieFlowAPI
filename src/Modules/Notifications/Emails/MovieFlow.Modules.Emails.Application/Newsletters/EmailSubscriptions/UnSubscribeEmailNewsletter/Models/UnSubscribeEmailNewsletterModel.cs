namespace MovieFlow.Modules.Emails.Application.Newsletters.EmailSubscriptions.UnSubscribeEmailNewsletter.Models;

public record UnSubscribeEmailNewsletterModel(string Email, DateTimeOffset UnSubscribedAt, string Subject);
