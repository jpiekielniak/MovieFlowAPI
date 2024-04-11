using MovieFlow.Modules.Users.Application.Users.Commands.DeleteUser;
using MovieFlow.Modules.Users.Core.Users.Entities;
using MovieFlow.Modules.Users.Core.Users.Exceptions.Users;
using MovieFlow.Modules.Users.Core.Users.Repositories;

namespace MovieFlow.Modules.Users.Tests.Unit.Handlers.Commands;

public class DeleteUserHandlerTests
{
    private async Task Act(DeleteUserCommand command)
        => await _handler.Handle(command, CancellationToken.None);

    [Fact]
    public async Task given_valid_userId_should_delete_user()
    {
        //Arrange
        var command = DeleteUserCommand();
        var user = CreateUser();
        _userRepository.GetAsync(command.UserId, Arg.Any<CancellationToken>())
            .Returns(user);
        _userRepository.DeleteAsync(user, Arg.Any<CancellationToken>())
            .Returns(Task.CompletedTask);
        
        //Act
        await Act(command);
        
        //Assert
        await _userRepository.Received(1).GetAsync(command.UserId, Arg.Any<CancellationToken>());
        await _userRepository.Received(1).DeleteAsync(user, Arg.Any<CancellationToken>());
    }
    
    [Fact]
    public async Task given_invalid_userId_should_throw_user_not_found_exception()
    {
        //Arrange
        var command = DeleteUserCommand();
        _userRepository.GetAsync(command.UserId, Arg.Any<CancellationToken>())
            .ReturnsNull();
        
        //Act
        var exception = await Record.ExceptionAsync(() => Act(command));
        
        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<UserNotFoundException>();
        await _userRepository.Received(1).GetAsync(command.UserId, Arg.Any<CancellationToken>());
        await _userRepository.DidNotReceive().DeleteAsync(Arg.Any<User>(), Arg.Any<CancellationToken>());
    }

    private readonly IRequestHandler<DeleteUserCommand> _handler;
    private readonly IUserRepository _userRepository;

    public DeleteUserHandlerTests()
    {
        _userRepository = Substitute.For<IUserRepository>();
        _handler = new DeleteUserHandler(_userRepository);
    }

    private static DeleteUserCommand DeleteUserCommand()
        => new(Guid.NewGuid());
}