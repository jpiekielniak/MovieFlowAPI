using MediatR;
using MovieFlow.Modules.Emails.Shared.Events.Newsletters.EmailSubscriptions.CreatedMovie;
using MovieFlow.Modules.Newsletters.Core.Newsletters.Repositories;
using MovieFlow.Modules.Newsletters.Shared.Events.CreatedMovie;

namespace MovieFlow.Modules.Newsletters.Application.EmailSubscriptions.Events.CreatedMovie;

internal sealed class CreatedMovieHandler(
    IEmailSubscriptionsRepository emailSubscriptionsRepository,
    IMediator mediator) : INotificationHandler<CreatedMovieEvent>
{
    public async Task Handle(CreatedMovieEvent @event, CancellationToken cancellationToken)
    {
        var emails = await emailSubscriptionsRepository.GetAllAsync(cancellationToken);

        var notification = new CreatedMovieEmailSubscriptionEvent(@event.Title, @event.Description, @event.ImageUrl, emails);
        await mediator.Publish(notification, cancellationToken);
    }
}