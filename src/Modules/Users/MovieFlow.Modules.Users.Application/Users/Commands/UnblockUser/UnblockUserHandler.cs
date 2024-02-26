using MovieFlow.Modules.Emails.Shared.Events.Users.UnblockUser;
using MovieFlow.Modules.Users.Core.Users.Exceptions.Users;
using MovieFlow.Modules.Users.Core.Users.Repositories;
using MovieFlow.Shared.Abstractions;
using MovieFlow.Shared.Abstractions.Time;

namespace MovieFlow.Modules.Users.Application.Users.Commands.UnblockUser;

internal sealed class UnblockUserHandler(IUserRepository userRepository,
    IMediator mediator, IClock clock) : IRequestHandler<UnblockUserCommand>
{
    public async Task Handle(UnblockUserCommand command, CancellationToken cancellationToken)
    {
        var user = await userRepository
            .GetAsync(command.UserId, cancellationToken)
            .NotNull(() => new UserNotFoundException(command.UserId));
        
        if(user.IsActive)
            throw new UserIsAlreadyActiveException(user.Id);

        user.Unblock();
        await userRepository.UpdateAsync(user, cancellationToken);

        var @event = new UnblockUserEvent(user.Email, clock.CurrentDateTimeOffset());
        await mediator.Publish(@event, cancellationToken);
    }
}