using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Recipient;

namespace MovieFlow.Modules.Emails.Core.Emails.Entities;

internal class Email
{
    public Guid Id { get; init; } = Guid.NewGuid();
    private Recipient Recipient { get; set; }
    private string Subject { get; set; }
    private string Message { get; set; }
    private DateTimeOffset SentAt { get; set; }

    private Email() //for EF
    {
    }

    private Email(Recipient recipient, string subject, string message, DateTimeOffset sentAt)
    {
        Recipient = recipient;
        Subject = subject;
        Message = message;
        SentAt = sentAt;
    }

    public static Email Create(Recipient recipient, string subject,
        string message, DateTimeOffset sentAt)
        => new(recipient, subject, message, sentAt);
}