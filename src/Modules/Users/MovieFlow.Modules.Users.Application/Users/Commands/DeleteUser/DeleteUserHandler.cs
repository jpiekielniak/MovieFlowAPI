using MovieFlow.Modules.Users.Core.Users.Exceptions.Users;
using MovieFlow.Modules.Users.Core.Users.Repositories;
using MovieFlow.Shared.Abstractions;

namespace MovieFlow.Modules.Users.Application.Users.Commands.DeleteUser;

internal sealed class DeleteUserHandler(IUserRepository userRepository) : IRequestHandler<DeleteUserCommand>
{
    public async Task Handle(DeleteUserCommand command,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.GetAsync(command.UserId, cancellationToken)
            .NotNull(() => new UserNotFoundException(command.UserId));

        await userRepository.DeleteAsync(user, cancellationToken);
    }
}