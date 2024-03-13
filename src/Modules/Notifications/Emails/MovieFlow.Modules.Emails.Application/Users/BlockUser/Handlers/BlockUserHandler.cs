using MovieFlow.Modules.Emails.Application.Users.BlockUser.Models;
using MovieFlow.Modules.Emails.Core.Emails.Entities;
using MovieFlow.Modules.Emails.Core.Emails.Repositories;
using MovieFlow.Modules.Emails.Core.Emails.Services;
using MovieFlow.Modules.Emails.Shared.Events.Users.BlockUser;

namespace MovieFlow.Modules.Emails.Application.Users.BlockUser.Handlers;

internal sealed class BlockUserHandler(IEmailRepository emailRepository,
    IEmailService emailService, IClock clock,
    IRazorViewRenderer razorViewRenderer) : INotificationHandler<BlockUserEvent>
{
    private const string PathView = "~/Users/BlockUser/Views/BlockUser.cshtml";
    private const string Subject = "Konto zostało zablokowane!";

    public async Task Handle(BlockUserEvent @event, CancellationToken cancellationToken)
    {
        var model = new BlockUserModel(@event.Email, @event.BlockedAt, Subject);
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