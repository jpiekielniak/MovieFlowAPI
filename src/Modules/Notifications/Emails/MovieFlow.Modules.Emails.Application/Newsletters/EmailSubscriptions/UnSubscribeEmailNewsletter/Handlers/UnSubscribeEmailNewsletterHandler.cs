using MovieFlow.Modules.Emails.Application.Newsletters.EmailSubscriptions.UnSubscribeEmailNewsletter.Models;
using MovieFlow.Modules.Emails.Core.Emails.Entities;
using MovieFlow.Modules.Emails.Core.Emails.Repositories;
using MovieFlow.Modules.Emails.Core.Emails.Services;
using MovieFlow.Modules.Emails.Shared.Events.Newsletters.EmailSubscriptions.UnSubscribeEmailNewsletter;

namespace MovieFlow.Modules.Emails.Application.Newsletters.EmailSubscriptions.UnSubscribeEmailNewsletter.Handlers;

internal sealed class SubscriptionEmailNewsletterHandler(
    IEmailRepository emailRepository,
    IEmailService emailService,
    IClock clock,
    IRazorViewRenderer razorViewRenderer) : INotificationHandler<UnSubscribedEmailNewsletterEvent>
{
    private const string PathView = "~/Newsletters/EmailSubscriptions/UnSubscribeEmailNewsletter/Views/UnSubscribeEmailNewsletter.cshtml";
    private const string Subject = "Pomyślnie wypisano z Newslettera!";

    public async Task Handle(UnSubscribedEmailNewsletterEvent @event, CancellationToken cancellationToken)
    {
        var model = new UnSubscribeEmailNewsletterModel(@event.Email, @event.UnSubscribedAt, Subject);
        var renderedView = await razorViewRenderer.RenderViewToStringAsync(PathView, model);
        var email = Email.Create(
            @event.Email,
            Subject,
            renderedView,
            clock.CurrentDateTimeOffset()
        );

        var status = await emailService.SendAsync(@event.Email, Subject, renderedView, renderedView);
        email.SetEmailStatus(status);
        await emailRepository.AddAsync(email, cancellationToken);
        await Task.CompletedTask;
    }
}