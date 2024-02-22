using MovieFlow.Modules.Users.Core.Users.Exceptions;
using MovieFlow.Modules.Users.Core.Users.Repositories;
using MovieFlow.Shared.Abstractions;

namespace MovieFlow.Modules.Users.Application.Users.Commands.UnblockUser;

internal sealed class UnblockUserHandler(IUserRepository userRepository) : IRequestHandler<UnblockUserCommand>
{
    public async Task Handle(UnblockUserCommand command, CancellationToken cancellationToken)
    {
        var user = await userRepository
            .GetAsync(command.UserId, cancellationToken)
            .NotNull(() => new UserNotFoundException(command.UserId));

        user.Unblock();
        await userRepository.UpdateAsync(user, cancellationToken);
    }
}