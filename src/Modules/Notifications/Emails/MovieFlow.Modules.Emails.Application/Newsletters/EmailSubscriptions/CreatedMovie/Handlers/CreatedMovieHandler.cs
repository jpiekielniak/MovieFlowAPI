using MovieFlow.Modules.Emails.Application.Newsletters.EmailSubscriptions.CreatedMovie.Models;
using MovieFlow.Modules.Emails.Core.Emails.Entities;
using MovieFlow.Modules.Emails.Core.Emails.Repositories;
using MovieFlow.Modules.Emails.Core.Emails.Services;
using MovieFlow.Modules.Emails.Shared.Events.Newsletters.EmailSubscriptions.CreatedMovie;

namespace MovieFlow.Modules.Emails.Application.Newsletters.EmailSubscriptions.CreatedMovie.Handlers;

internal sealed class CreatedMovieHandler(
    IEmailRepository emailRepository,
    IEmailService emailService,
    IClock clock,
    IRazorViewRenderer razorViewRenderer) : INotificationHandler<CreatedMovieEmailSubscriptionEvent>
{
    private const string PathView = "~/Newsletters/EmailSubscriptions/CreatedMovie/Views/CreatedMovieEmailSubscription.cshtml";
    private const string Subject = "Newsletter - Dodano nowy film!";

    public async Task Handle(CreatedMovieEmailSubscriptionEvent @event, CancellationToken cancellationToken)
    {
        var model = new CreatedMovieEmailSubscriptionModel(@event.Title, @event.Description, @event.ImageUrl, Subject);
        var renderedView = await razorViewRenderer.RenderViewToStringAsync(PathView, model);

        foreach (var emailSubscription in @event.Emails)
        {
            var email = Email.Create(
                emailSubscription,
                Subject,
                renderedView,
                clock.CurrentDateTimeOffset()
            );

            var status = await emailService.SendAsync(emailSubscription, Subject, renderedView, renderedView);
            email.SetEmailStatus(status);
            await emailRepository.AddAsync(email, cancellationToken);
        }

        await Task.CompletedTask;
    }
}