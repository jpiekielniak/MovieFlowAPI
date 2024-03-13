using MediatR;
using MovieFlow.Modules.Emails.Shared.Events.Newsletters.SubscribeEmailNewsletter;
using MovieFlow.Modules.Newsletters.Core.Newsletters.Entities;
using MovieFlow.Modules.Newsletters.Core.Newsletters.Exceptions.EmailSubscriptions;
using MovieFlow.Modules.Newsletters.Core.Newsletters.Repositories;
using MovieFlow.Shared.Abstractions.Time;

namespace MovieFlow.Modules.Newsletters.Application.EmailSubscriptions.Commands.SubscriptionEmailNewsletter;

internal sealed class SubscriptionEmailNewsletterHandler(
    IEmailSubscriptionsRepository emailSubscriptionsRepository,
    IMediator mediator,
    IClock clock) : IRequestHandler<SubscriptionEmailNewsletterCommand>
{
    public async Task Handle(SubscriptionEmailNewsletterCommand command, CancellationToken cancellationToken)
    {
        var subscriptionExist = await emailSubscriptionsRepository
            .CheckEmailExistsAsync(command.Email, cancellationToken);

        if (subscriptionExist)
            throw new EmailSubscriptionAlreadyExistsException(command.Email);

        var subscription = EmailSubscription.Create(command.Email);

        await emailSubscriptionsRepository.AddAsync(subscription, cancellationToken);

        var @event = new SubscribedEmailNewsletterEvent(command.Email, clock.CurrentDateTimeOffset());
        await mediator.Publish(@event, cancellationToken);
    }
}