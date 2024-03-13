using MediatR;

namespace MovieFlow.Modules.Newsletters.Application.EmailSubscriptions.Commands.SubscribeEmailNewsletter;

internal record SubscribeEmailNewsletterCommand(string Email) : IRequest;
