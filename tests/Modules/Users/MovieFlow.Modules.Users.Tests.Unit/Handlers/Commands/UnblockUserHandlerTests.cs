using MovieFlow.Modules.Emails.Shared.Events.Users.UnblockUser;
using MovieFlow.Modules.Users.Application.Users.Commands.UnblockUser;
using MovieFlow.Modules.Users.Core.Users.Entities;
using MovieFlow.Modules.Users.Core.Users.Exceptions.Users;
using MovieFlow.Modules.Users.Core.Users.Repositories;
using MovieFlow.Shared.Abstractions.Time;

namespace MovieFlow.Modules.Users.Tests.Unit.Handlers.Commands;

public class UnblockUserHandlerTests
{
    private async Task Act(UnblockUserCommand command)
        => await _handler.Handle(command, CancellationToken.None);

    [Fact]
    public async Task given_invalid_userId_should_throw_user_not_found_exception()
    {
        //Arrange
        var command = UnblockUserCommand();
        _userRepository.GetAsync(command.UserId, Arg.Any<CancellationToken>())
            .ReturnsNull();

        //Act
        var exception = await Record.ExceptionAsync(() => Act(command));

        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<UserNotFoundException>();
        await _userRepository.Received(1).GetAsync(command.UserId, Arg.Any<CancellationToken>());
        await _userRepository.DidNotReceive().UpdateAsync(Arg.Any<User>(), Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task given_user_is_already_active_should_throw_user_is_already_active_exception()
    {
        //Arrange
        var command = UnblockUserCommand();
        var user = CreateUser();
        _userRepository.GetAsync(command.UserId, Arg.Any<CancellationToken>())
            .Returns(user);

        //Act
        var exception = await Record.ExceptionAsync(() => Act(command));

        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<UserIsAlreadyActiveException>();
        user.IsActive.ShouldBeTrue();
        await _userRepository.Received(1).GetAsync(command.UserId, Arg.Any<CancellationToken>());
        await _userRepository.DidNotReceive().UpdateAsync(Arg.Any<User>(), Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task given_valid_userId_should_unblock_user()
    {
        //Arrange
        var command = UnblockUserCommand();
        var user = CreateUser();
        user.Block();
        _userRepository.GetAsync(command.UserId, Arg.Any<CancellationToken>())
            .Returns(user);

        //Act
        await Act(command);

        //Assert
        user.IsActive.ShouldBeTrue();
        await _userRepository.Received(1).GetAsync(command.UserId, Arg.Any<CancellationToken>());
        await _userRepository.Received(1).UpdateAsync(user, Arg.Any<CancellationToken>());
        await _mediator.Received(1).Publish(Arg.Any<UnblockUserEvent>(), Arg.Any<CancellationToken>());
    }

    private readonly IRequestHandler<UnblockUserCommand> _handler;
    private readonly IUserRepository _userRepository;
    private readonly IMediator _mediator;

    public UnblockUserHandlerTests()
    {
        _userRepository = Substitute.For<IUserRepository>();
        _mediator = Substitute.For<IMediator>();
        var clock = Substitute.For<IClock>();

        _handler = new UnblockUserHandler(
            _userRepository,
            _mediator,
            clock
        );
    }

    private static UnblockUserCommand UnblockUserCommand() => new(Guid.NewGuid());
}