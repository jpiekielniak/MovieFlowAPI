using MovieFlow.Modules.Users.Core.Users.Exceptions;
using MovieFlow.Modules.Users.Core.Users.Repositories;
using MovieFlow.Shared.Abstractions;
using MovieFlow.Shared.Abstractions.Auth;

namespace MovieFlow.Modules.Users.Application.Users.Commands.SignIn;

internal sealed class SignInHandler(IUserRepository userRepository,
    IAuthManager authManager, IPasswordHasher<Core.Users.Entities.User> passwordHasher) 
    : IRequestHandler<SignInCommand, SignInResponse>
{
    public async Task<SignInResponse> Handle(SignInCommand command, 
        CancellationToken cancellationToken)
    {
        var user = await userRepository
            .GetByEmailAsync(command.Email)
            .NotNull(() => new InvalidCredentialsException());

        if (!user.IsActive)
            throw new UserNotActiveException(user.Id);

        var isValidPassword = passwordHasher
            .VerifyHashedPassword(user,
                user.Password,
                command.Password
            ) == PasswordVerificationResult.Success;

        if (!isValidPassword)
            throw new InvalidCredentialsException();

        var claims = new Dictionary<string, IEnumerable<string>>
        {
            ["permissions"] = user.Role.Permissions
        };

        var jwt = authManager.CreateToken(user.Id.ToString(), user.Role.Name, claims: claims);
        jwt.Email = user.Email;

        return new SignInResponse(jwt);
    }
}