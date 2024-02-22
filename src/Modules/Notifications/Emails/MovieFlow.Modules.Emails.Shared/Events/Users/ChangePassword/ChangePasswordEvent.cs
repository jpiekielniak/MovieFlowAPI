using MediatR;

namespace MovieFlow.Modules.Emails.Shared.Events.Users.ChangePassword;

public record ChangePasswordEvent(string Email, DateTimeOffset ChangedAt) : INotification;