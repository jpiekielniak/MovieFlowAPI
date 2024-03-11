using MovieFlow.Modules.Emails.Application.Users.ChangePassword.Models;
using MovieFlow.Modules.Emails.Core.Emails.Entities;
using MovieFlow.Modules.Emails.Core.Emails.Repositories;
using MovieFlow.Modules.Emails.Core.Emails.Services;
using MovieFlow.Modules.Emails.Shared.Events.Users.ChangePassword;

namespace MovieFlow.Modules.Emails.Application.Users.ChangePassword.Handlers;

internal sealed class ChangePasswordHandler(IEmailRepository emailRepository,
    IEmailService emailService, IClock clock,
    IRazorViewRenderer razorViewRenderer) : INotificationHandler<ChangePasswordEvent>
{
    private const string PathView = "~/Users/ChangePassword/Views/ChangePassword.cshtml";
    private const string Subject = "Haslo zmienione pomyślnie!";

    public async Task Handle(ChangePasswordEvent @event, CancellationToken cancellationToken)
    {
        var model = new ChangePasswordModel(@event.ChangedAt, Subject);
        var renderedView = await razorViewRenderer.RenderViewToStringAsync(PathView, model);
        var email = Email.Create(
            @event.Email,
            Subject,
            renderedView,
            clock.CurrentDateTimeOffset()
        );

        await emailService.SendAsync(@event.Email, Subject, renderedView, renderedView);
        await emailRepository.AddAsync(email, cancellationToken);
        await Task.CompletedTask;
    }
}