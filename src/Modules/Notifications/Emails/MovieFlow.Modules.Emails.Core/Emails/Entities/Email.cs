using MovieFlow.Modules.Emails.Core.Emails.Enums;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Recipient;

namespace MovieFlow.Modules.Emails.Core.Emails.Entities;

internal class Email
{
    public Guid Id { get; init; } = Guid.NewGuid();
    private Recipient Recipient { get; set; }
    private string Subject { get; set; }
    private string Message { get; set; }
    private DateTimeOffset SentAt { get; set; }
    private EmailMessageStatus Status { get; set; }

    private Email()
    {
    }

    private Email(Recipient recipient, string subject, string message, DateTimeOffset sentAt)
    {
        Recipient = recipient;
        Subject = subject;
        Message = message;
        SentAt = sentAt;
        Status = EmailMessageStatus.None;
    }

    public static Email Create(Recipient recipient, string subject,
        string message, DateTimeOffset sentAt)
        => new(recipient, subject, message, sentAt);

    public void SetEmailStatus(EmailMessageStatus status) => Status = status;
}