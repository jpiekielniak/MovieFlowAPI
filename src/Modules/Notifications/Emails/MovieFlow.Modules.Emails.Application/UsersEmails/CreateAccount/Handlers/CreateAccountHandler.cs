using MediatR;
using MovieFlow.Modules.Emails.Application.UsersEmails.CreateAccount.Models;
using MovieFlow.Modules.Emails.Core.Emails.Entities;
using MovieFlow.Modules.Emails.Core.Emails.Repositories;
using MovieFlow.Modules.Emails.Core.Emails.Services;
using MovieFlow.Modules.Emails.Shared.Events.Users;
using MovieFlow.Shared.Abstractions.RenderView;
using MovieFlow.Shared.Abstractions.Time;

namespace MovieFlow.Modules.Emails.Application.UsersEmails.CreateAccount.Handlers;

internal sealed class CreateAccountHandler(
    IEmailRepository emailRepository,
    IEmailService emailService,
    IClock clock,
    IRazorViewRenderer razorViewRenderer)
    : INotificationHandler<CreateAccountEvent>
{
    private const string PathView = "~/UsersEmails/CreateAccount/Views/CreateAccount.cshtml";
    private const string Subject = "Welcome to MovieFlow";

    public async Task Handle(CreateAccountEvent @event,
        CancellationToken cancellationToken)
    {
        var model = new CreateAccountModel(@event.Email, @event.Password, Subject);
        var renderedView = await razorViewRenderer.RenderViewToStringAsync(PathView, model);
        var email = Email.Create(@event.Email, Subject, renderedView, clock.CurrentDateTimeOffset());

        await emailService.SendAsync(@event.Email, Subject, renderedView, renderedView);
        await emailRepository.AddAsync(email, cancellationToken);
        await Task.CompletedTask;
    }
}