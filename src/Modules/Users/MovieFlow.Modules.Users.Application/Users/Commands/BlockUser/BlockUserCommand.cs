namespace MovieFlow.Modules.Users.Application.Users.Commands.BlockUser;

public record BlockUserCommand(Guid UserId) : IRequest;
