using MovieFlow.Modules.Emails.Shared.Events.Newsletters.EmailSubscriptions.SubscribeEmailNewsletter;
using MovieFlow.Modules.Newsletters.Core.Newsletters.Entities;
using MovieFlow.Modules.Newsletters.Core.Newsletters.Exceptions.EmailSubscriptions;
using MovieFlow.Modules.Newsletters.Core.Newsletters.Repositories;
using MovieFlow.Shared.Abstractions.Time;

namespace MovieFlow.Modules.Newsletters.Application.EmailSubscriptions.Commands.SubscribeEmailNewsletter;

internal sealed class SubscribeEmailNewsletterHandler(
    IEmailSubscriptionsRepository emailSubscriptionsRepository,
    IMediator mediator,
    IClock clock) : IRequestHandler<SubscribeEmailNewsletterCommand>
{
    public async Task Handle(SubscribeEmailNewsletterCommand command, CancellationToken cancellationToken)
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