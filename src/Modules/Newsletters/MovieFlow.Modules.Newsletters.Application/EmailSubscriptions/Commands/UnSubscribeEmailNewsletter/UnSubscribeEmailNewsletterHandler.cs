using MediatR;
using MovieFlow.Modules.Emails.Shared.Events.Newsletters.EmailSubscriptions.UnSubscribeEmailNewsletter;
using MovieFlow.Modules.Newsletters.Core.Newsletters.Exceptions.EmailSubscriptions;
using MovieFlow.Modules.Newsletters.Core.Newsletters.Repositories;
using MovieFlow.Shared.Abstractions;
using MovieFlow.Shared.Abstractions.Time;

namespace MovieFlow.Modules.Newsletters.Application.EmailSubscriptions.Commands.UnSubscribeEmailNewsletter;

internal sealed class UnSubscribeEmailNewsletterHandler(
    IEmailSubscriptionsRepository emailSubscriptionsRepository,
    IMediator mediator,
    IClock clock) : IRequestHandler<UnSubscribeEmailNewsletterCommand>
{
    public async Task Handle(UnSubscribeEmailNewsletterCommand command, CancellationToken cancellationToken)
    {
        var email = await emailSubscriptionsRepository
            .GetAsync(command.Email, cancellationToken)
            .NotNull(() => new EmailSubscriptionNotFoundException(command.Email));

        await emailSubscriptionsRepository.DeleteAsync(email, cancellationToken);

        var @event = new UnSubscribedEmailNewsletterEvent(command.Email, clock.CurrentDateTimeOffset());
        await mediator.Publish(@event, cancellationToken);
    }
}