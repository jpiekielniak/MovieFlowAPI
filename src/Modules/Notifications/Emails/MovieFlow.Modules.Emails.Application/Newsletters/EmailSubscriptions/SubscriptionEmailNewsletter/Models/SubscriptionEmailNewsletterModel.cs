namespace MovieFlow.Modules.Emails.Application.Newsletters.EmailSubscriptions.SubscriptionEmailNewsletter.Models;

public record SubscriptionEmailNewsletterModel(string Email, DateTimeOffset JoinedAt, string Subject);
