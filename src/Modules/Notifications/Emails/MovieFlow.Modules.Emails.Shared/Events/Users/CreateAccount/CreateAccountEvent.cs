namespace MovieFlow.Modules.Emails.Shared.Events.Users.CreateAccount;

public record CreateAccountEvent(string Email, string Password) : INotification;