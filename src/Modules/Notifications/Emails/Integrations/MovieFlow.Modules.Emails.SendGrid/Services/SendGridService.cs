using System.Net;
using MovieFlow.Modules.Emails.Core.Emails.Enums;
using MovieFlow.Modules.Emails.Core.Emails.Services;
using MovieFlow.Modules.Emails.SendGrid.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace MovieFlow.Modules.Emails.SendGrid.Services;

internal class SendGridService(ISendGridConfiguration sendGridConfiguration) : IEmailService
{
    private readonly string _apiKey = sendGridConfiguration.API_KEY;
    private readonly string _sender = sendGridConfiguration.Sender;
    private readonly string _senderName = sendGridConfiguration.SenderName;

    public async Task<EmailMessageStatus> SendAsync(string recipient, string subject, string plaintTextContent,
        string htmlContent)
    {
        var client = new SendGridClient(_apiKey);
        var from = new EmailAddress(_sender, _senderName);
        var to = new EmailAddress(recipient);
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plaintTextContent, htmlContent);
        var response = await client.SendEmailAsync(msg);

        return response.StatusCode is HttpStatusCode.Accepted or HttpStatusCode.OK
            ? EmailMessageStatus.Sent
            : EmailMessageStatus.Failed;
    }
}