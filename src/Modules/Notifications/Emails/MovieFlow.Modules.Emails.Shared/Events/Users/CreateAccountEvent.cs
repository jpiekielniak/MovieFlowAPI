using MediatR;

namespace MovieFlow.Modules.Emails.Shared.Events.Users;

public record CreateAccountEvent(string Email, string Password) : INotification;