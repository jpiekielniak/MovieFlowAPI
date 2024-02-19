using MovieFlow.Modules.Users.Core.Users.Exceptions;
using MovieFlow.Modules.Users.Core.Users.Repositories;
using MovieFlow.Shared.Abstractions;

namespace MovieFlow.Modules.Users.Api.Endpoints.User.Commands.Delete;

internal sealed class DeleteUserHandler(IUserRepository userRepository) : IRequestHandler<DeleteUserCommand>
{
    public async Task Handle(DeleteUserCommand command,
        CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserAsync(command.userId)
            .NotNull(() => new UserNotFoundException(command.userId));

        await userRepository.DeleteAsync(user, cancellationToken);
    }
}