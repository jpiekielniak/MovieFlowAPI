using MovieFlow.Modules.Users.Core.Users.Entities;
using MovieFlow.Modules.Users.Core.Users.Exceptions;
using MovieFlow.Modules.Users.Core.Users.Repositories;
using MovieFlow.Shared.Abstractions;
using MovieFlow.Shared.Abstractions.Contexts;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Password.Exceptions;
using MovieFlow.Shared.Abstractions.Time;

namespace MovieFlow.Modules.Users.Application.Users.Commands.ChangePassword;

internal sealed class ChangePasswordHandler(IClock clock,
    IUserRepository userRepository, IPasswordHasher<User> passwordHasher,
    IContext context) : IRequestHandler<ChangePasswordCommand>
{
    public async Task Handle(ChangePasswordCommand command,
        CancellationToken cancellationToken)
    {
        var user = await userRepository
            .GetAsync(context.Identity.Id, cancellationToken)
            .NotNull(() => new UserNotFoundException(context.Identity.Id));

        var passwordVerified = passwordHasher.VerifyHashedPassword(default, user.Password,
            command.CurrentPassword) == PasswordVerificationResult.Success;

        if (!passwordVerified)
            throw new InvalidPasswordException(command.CurrentPassword);

        if (command.NewPassword != command.ConfirmNewPassword)
            throw new PasswordsDoNotMatchException("Passwords do not match");

        var newPassword = passwordHasher.HashPassword(default, command.NewPassword);
        user.SetPassword(newPassword, clock.CurrentDateTimeOffset());
        await userRepository.UpdateAsync(user, cancellationToken);
    }
}