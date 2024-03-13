using MediatR;

namespace MovieFlow.Modules.Newsletters.Application.EmailSubscriptions.Commands.SubscriptionEmailNewsletter;

internal record SubscriptionEmailNewsletterCommand(string Email) : IRequest;
