using MovieFlow.Modules.Emails.Shared.Events.Users.BlockUser;
using MovieFlow.Modules.Users.Core.Users.Exceptions;
using MovieFlow.Modules.Users.Core.Users.Repositories;
using MovieFlow.Shared.Abstractions;
using MovieFlow.Shared.Abstractions.Contexts;
using MovieFlow.Shared.Abstractions.Time;

namespace MovieFlow.Modules.Users.Application.Users.Commands.BlockUser;

internal sealed class BlockUserHandler(IContext context,
    IClock clock, IUserRepository userRepository,
    IMediator mediator) : IRequestHandler<BlockUserCommand>
{
    public async Task Handle(BlockUserCommand command, CancellationToken cancellationToken)
    {
        if (context.Identity.Id == command.UserId)
            throw new CannotBlockYourselfException("You cannot block yourself");

        var user = await userRepository
            .GetAsync(command.UserId, cancellationToken)
            .NotNull(() => new UserNotFoundException(command.UserId));

        user.Block();
        await userRepository.UpdateAsync(user, cancellationToken);

        var @event = new BlockUserEvent(user.Email, clock.CurrentDateTimeOffset());
        await mediator.Publish(@event, cancellationToken);
    }
}