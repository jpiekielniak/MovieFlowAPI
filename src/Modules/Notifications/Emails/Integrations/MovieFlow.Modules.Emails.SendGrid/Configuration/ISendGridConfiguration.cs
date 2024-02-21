namespace MovieFlow.Modules.Emails.SendGrid.Configuration;

public interface ISendGridConfiguration
{
    string API_KEY { get; }
    string Sender { get; }
    string SenderName { get; }
}