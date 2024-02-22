namespace MovieFlow.Modules.Emails.Application.Users.BlockUser.Models;

public record BlockUserModel(string Email, DateTimeOffset BlockedAt, string Subject);
