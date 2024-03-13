namespace MovieFlow.Modules.Emails.Application.Newsletters.SubscriptionEmailNewsletter.Models;

public record SubscriptionEmailNewsletterModel(string Email, DateTimeOffset JoinedAt, string Subject);
