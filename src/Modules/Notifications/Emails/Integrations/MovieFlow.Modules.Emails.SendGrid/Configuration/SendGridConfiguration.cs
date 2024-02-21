using Microsoft.Extensions.Configuration;

namespace MovieFlow.Modules.Emails.SendGrid.Configuration;

internal sealed class SendGridConfiguration(IConfiguration configuration) : ISendGridConfiguration
{
    private const string SectionName = "sendGrid";
    private readonly IConfiguration _configuration = configuration.GetSection(SectionName);

    public string API_KEY => _configuration.GetValue<string>(nameof(API_KEY));
    public string Sender => _configuration.GetValue<string>(nameof(Sender));
    public string SenderName => _configuration.GetValue<string>(nameof(SenderName));
}