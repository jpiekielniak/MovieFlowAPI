namespace MovieFlow.Modules.Users.Api.Endpoints.User.Commands.Delete;

internal record DeleteUserCommand(Guid userId) : IRequest;