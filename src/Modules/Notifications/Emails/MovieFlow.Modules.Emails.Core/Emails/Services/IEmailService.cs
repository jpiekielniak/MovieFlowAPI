using System.Runtime.CompilerServices;
using MovieFlow.Modules.Emails.Core.Emails.Enums;

[assembly: InternalsVisibleTo("MovieFlow.Modules.Emails.SendGrid")]

namespace MovieFlow.Modules.Emails.Core.Emails.Services;

internal interface IEmailService
{
    Task<EmailMessageStatus> SendAsync(string recipient, string subject, string plainTextContent, string htmlContent);
}