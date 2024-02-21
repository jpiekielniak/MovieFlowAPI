using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("MovieFlow.Modules.Emails.SendGrid")]

namespace MovieFlow.Modules.Emails.Core.Emails.Services;

internal interface IEmailService
{
    Task SendAsync(string recipient, string subject, string plainTextContent, string htmlContent);
}