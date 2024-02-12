using MediatR;

namespace MovieFlow.Modules.Users.Application.Users.Commands.SignUp;

internal record SignUpCommand(
    string Name,
    string Email,
    string Password,
    string ConfirmPassword) : IRequest<SignUpResponse>;