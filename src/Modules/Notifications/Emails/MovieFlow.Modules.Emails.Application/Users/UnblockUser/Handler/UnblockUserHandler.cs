using MovieFlow.Modules.Emails.Application.Users.UnblockUser.Models;
using MovieFlow.Modules.Emails.Core.Emails.Entities;
using MovieFlow.Modules.Emails.Core.Emails.Repositories;
using MovieFlow.Modules.Emails.Core.Emails.Services;
using MovieFlow.Modules.Emails.Shared.Events.Users.UnblockUser;

namespace MovieFlow.Modules.Emails.Application.Users.UnblockUser.Handler;

internal sealed class UnblockUserHandler(IEmailRepository emailRepository,
    IEmailService emailService, IRazorViewRenderer razorViewRenderer,
    IClock clock) : INotificationHandler<UnblockUserEvent>
{
    private const string PathView = "~/Users/UnblockUser/Views/UnblockUser.cshtml";
    private const string Subject = "Konto zostało odblokowane!";

    public async Task Handle(UnblockUserEvent @event, CancellationToken cancellationToken)
    {
        var model = new UnblockUserModel(@event.Email, @event.UnblockedAt, Subject);
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