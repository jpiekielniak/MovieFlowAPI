namespace MovieFlow.Modules.Emails.Application.Users.UnblockUser.Models;

public record UnblockUserModel(string Email, DateTimeOffset UnblockedAt, string Subject);