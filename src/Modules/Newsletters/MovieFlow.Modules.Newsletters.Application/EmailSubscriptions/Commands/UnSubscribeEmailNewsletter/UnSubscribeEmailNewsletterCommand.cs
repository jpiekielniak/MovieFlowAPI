namespace MovieFlow.Modules.Newsletters.Application.EmailSubscriptions.Commands.UnSubscribeEmailNewsletter;

internal record UnSubscribeEmailNewsletterCommand(string Email) : IRequest;