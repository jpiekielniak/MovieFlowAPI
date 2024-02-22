using MediatR;

namespace MovieFlow.Modules.Emails.Shared.Events.Users.BlockUser;

public record BlockUserEvent(string Email, DateTimeOffset BlockedAt) : INotification;