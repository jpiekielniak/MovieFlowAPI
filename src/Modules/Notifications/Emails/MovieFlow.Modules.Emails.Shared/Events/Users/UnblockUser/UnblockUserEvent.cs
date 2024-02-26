using MediatR;

namespace MovieFlow.Modules.Emails.Shared.Events.Users.UnblockUser;

public record UnblockUserEvent(string Email, DateTimeOffset UnblockedAt) : INotification;