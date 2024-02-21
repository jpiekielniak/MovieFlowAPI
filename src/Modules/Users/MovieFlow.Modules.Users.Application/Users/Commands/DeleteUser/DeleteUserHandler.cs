using MovieFlow.Modules.Users.Core.Users.Exceptions;
using MovieFlow.Modules.Users.Core.Users.Repositories;
using MovieFlow.Shared.Abstractions;

namespace MovieFlow.Modules.Users.Application.Users.Commands.DeleteUser;

internal sealed class DeleteUserHandler(IUserRepository userRepository) : IRequestHandler<DeleteUserCommand>
{
    public async Task Handle(DeleteUserCommand command,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserAsync(command.UserId)
            .NotNull(() => new UserNotFoundException(command.UserId));

        await userRepository.DeleteAsync(user, cancellationToken);
    }
}