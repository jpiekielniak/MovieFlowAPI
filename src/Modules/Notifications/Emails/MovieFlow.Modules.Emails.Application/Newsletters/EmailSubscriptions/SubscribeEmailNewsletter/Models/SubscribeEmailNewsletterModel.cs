namespace MovieFlow.Modules.Emails.Application.Newsletters.EmailSubscriptions.SubscribeEmailNewsletter.Models;

public record SubscribeEmailNewsletterModel(string Email, DateTimeOffset JoinedAt, string Subject);
