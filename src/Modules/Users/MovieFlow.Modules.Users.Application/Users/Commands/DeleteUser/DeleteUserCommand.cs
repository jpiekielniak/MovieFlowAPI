namespace MovieFlow.Modules.Users.Application.Users.Commands.DeleteUser;

internal record DeleteUserCommand(Guid UserId) : IRequest;