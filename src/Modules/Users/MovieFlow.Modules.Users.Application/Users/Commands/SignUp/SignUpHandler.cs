using MediatR;
using Microsoft.AspNetCore.Identity;
using MovieFlow.Modules.Users.Core.Users.Entities;
using MovieFlow.Modules.Users.Core.Users.Exceptions;
using MovieFlow.Modules.Users.Core.Users.Repositories;
using MovieFlow.Shared.Abstractions;

namespace MovieFlow.Modules.Users.Application.Users.Commands.SignUp;

internal sealed class SignUpHandler(
    IPasswordHasher<User> passwordHasher,
    IRoleRepository roleRepository,
    IUserRepository userRepository) : IRequestHandler<SignUpCommand, SignUpResponse>
{
    private const string UserRole = "User";
    private const string UserExceptionMessage = "User with this email or name already exists";
    private const string PasswordExceptionMessage = "Passwords do not match";
    public async Task<SignUpResponse> Handle(SignUpCommand command, CancellationToken cancellationToken)
    {
        var userExists = await userRepository.UserExistsAsync(command.Email, command.Name);

        if (userExists)
            throw new UserAlreadyExistsException(UserExceptionMessage);
        
        if(command.Password != command.ConfirmPassword)
            throw new PasswordsDoNotMatchException(PasswordExceptionMessage);

        var role = await roleRepository.GetAsync(UserRole, cancellationToken)
            .NotNull(() => new RoleNotFoundException(UserRole));

        var hashPassword = passwordHasher.HashPassword(default, command.Password);

        var user = User.Create(
            command.Name,
            command.Email,
            hashPassword,
            role);
        
        await userRepository.AddAsync(user, cancellationToken);

        return new SignUpResponse(user.Id);
    }
}