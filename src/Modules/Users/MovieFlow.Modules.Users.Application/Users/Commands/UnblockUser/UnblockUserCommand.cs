namespace MovieFlow.Modules.Users.Application.Users.Commands.UnblockUser;

internal record UnblockUserCommand(Guid UserId) : IRequest;