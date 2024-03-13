using MovieFlow.Modules.Emails.Application.Users.CreateAccount.Models;
using MovieFlow.Modules.Emails.Core.Emails.Entities;
using MovieFlow.Modules.Emails.Core.Emails.Repositories;
using MovieFlow.Modules.Emails.Core.Emails.Services;
using MovieFlow.Modules.Emails.Shared.Events.Users.CreateAccount;

namespace MovieFlow.Modules.Emails.Application.Users.CreateAccount.Handlers;

internal sealed class CreateAccountHandler(IEmailRepository emailRepository,
    IEmailService emailService, IClock clock, IRazorViewRenderer razorViewRenderer)
    : INotificationHandler<CreateAccountEvent>
{
    private const string PathView = "~/Users/CreateAccount/Views/CreateAccount.cshtml";
    private const string Subject = "Witamy w MovieFlow";

    public async Task Handle(CreateAccountEvent @event,
        CancellationToken cancellationToken)
    {
        var model = new CreateAccountModel(@event.Email, @event.Password, Subject);
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