using MovieFlow.Modules.Emails.Shared.Events.Users.CreateAccount;
using MovieFlow.Modules.Users.Core.Users.Entities;
using MovieFlow.Modules.Users.Core.Users.Exceptions.Roles;
using MovieFlow.Modules.Users.Core.Users.Exceptions.Users;
using MovieFlow.Modules.Users.Core.Users.Repositories;
using MovieFlow.Shared.Abstractions;
using PasswordGenerator;

namespace MovieFlow.Modules.Users.Application.Users.Commands.SignUp;

internal sealed class SignUpHandler(IPasswordHasher<User> passwordHasher,
    IRoleRepository roleRepository, IUserRepository userRepository, 
    IMediator mediator) : IRequestHandler<SignUpCommand, SignUpResponse>
{
    private const string UserRole = "User";
    private const string UserExceptionMessage = "User with this email or name already exists";

    public async Task<SignUpResponse> Handle(SignUpCommand command, 
        CancellationToken cancellationToken)
    {
        var userExists = await userRepository.UserExistsAsync(command.Email, command.Name);

        if (userExists)
            throw new UserAlreadyExistsException(UserExceptionMessage);

        var role = await roleRepository.GetAsync(UserRole, cancellationToken)
            .NotNull(() => new RoleNotFoundException(UserRole));

        var password = new Password(12).Next();
        var hashPassword = passwordHasher.HashPassword(default, password);

        var user = User.Create(
            command.Name,
            command.Email,
            hashPassword,
            role);

        await userRepository.AddAsync(user, cancellationToken);

        var notifications = new CreateAccountEvent(user.Email, password);
        await mediator.Publish(notifications, cancellationToken);

        return new SignUpResponse(user.Id);
    }
}