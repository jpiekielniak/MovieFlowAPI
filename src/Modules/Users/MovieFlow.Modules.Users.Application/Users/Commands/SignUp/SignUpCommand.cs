namespace MovieFlow.Modules.Users.Application.Users.Commands.SignUp;

internal record SignUpCommand(string Name, string Password, string Email) : IRequest<SignUpResponse>;