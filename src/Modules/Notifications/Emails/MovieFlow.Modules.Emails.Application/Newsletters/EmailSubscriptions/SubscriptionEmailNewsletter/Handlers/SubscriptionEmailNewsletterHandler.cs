using MovieFlow.Modules.Emails.Application.Newsletters.EmailSubscriptions.SubscriptionEmailNewsletter.Models;
using MovieFlow.Modules.Emails.Core.Emails.Entities;
using MovieFlow.Modules.Emails.Core.Emails.Repositories;
using MovieFlow.Modules.Emails.Core.Emails.Services;
using MovieFlow.Modules.Emails.Shared.Events.Newsletters.EmailSubscriptions.SubscribeEmailNewsletter;

namespace MovieFlow.Modules.Emails.Application.Newsletters.EmailSubscriptions.SubscriptionEmailNewsletter.Handlers;

internal sealed class SubscriptionEmailNewsletterHandler(
    IEmailRepository emailRepository,
    IEmailService emailService,
    IClock clock,
    IRazorViewRenderer razorViewRenderer) : INotificationHandler<SubscribedEmailNewsletterEvent>
{
    private const string PathView = "~/Newsletters/EmailSubscriptions/SubscriptionEmailNewsletter/Views/SubscriptionEmailNewsletter.cshtml";
    private const string Subject = "Zapisano do newslettera!";

    public async Task Handle(SubscribedEmailNewsletterEvent @event, CancellationToken cancellationToken)
    {
        var model = new SubscriptionEmailNewsletterModel(@event.Email, @event.JoinedAt, Subject);
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