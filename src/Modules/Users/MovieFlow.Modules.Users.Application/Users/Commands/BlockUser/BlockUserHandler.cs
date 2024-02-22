using MovieFlow.Modules.Users.Core.Users.Exceptions;
using MovieFlow.Modules.Users.Core.Users.Repositories;
using MovieFlow.Shared.Abstractions;
using MovieFlow.Shared.Abstractions.Contexts;

namespace MovieFlow.Modules.Users.Application.Users.Commands.BlockUser;

internal sealed class BlockUserHandler(IContext context,
    IUserRepository userRepository) : IRequestHandler<BlockUserCommand>
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
    }
}