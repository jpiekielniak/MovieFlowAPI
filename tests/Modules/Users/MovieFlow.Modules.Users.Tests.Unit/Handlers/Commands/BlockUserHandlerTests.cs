using MovieFlow.Modules.Emails.Shared.Events.Users.BlockUser;
using MovieFlow.Modules.Users.Application.Users.Commands.BlockUser;
using MovieFlow.Modules.Users.Core.Users.Entities;
using MovieFlow.Modules.Users.Core.Users.Exceptions.Users;
using MovieFlow.Modules.Users.Core.Users.Repositories;
using MovieFlow.Shared.Abstractions.Contexts;
using MovieFlow.Shared.Abstractions.Time;

namespace MovieFlow.Modules.Users.Tests.Unit.Handlers.Commands;

public class BlockUserHandlerTests
{
    private async Task Act(BlockUserCommand command)
        => await _handler.Handle(command, CancellationToken.None);

    [Fact]
    public async Task given_current_logged_userId_should_throw_cannot_block_yourself_exception()
    {
        // Arrange
        var command = BlockUserCommand();
        _context.Identity.Id.Returns(command.UserId);

        //Act
        var exception = await Record.ExceptionAsync(() => Act(command));

        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<CannotBlockYourselfException>();
        await _userRepository.DidNotReceive().GetAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>());
        await _userRepository.DidNotReceive().UpdateAsync(Arg.Any<User>(), Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task given_invalid_userId_should_throw_user_not_found_exception()
    {
        //Arrange
        var command = BlockUserCommand();
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
    public async Task given_user_is_already_blocked_should_throw_user_is_already_blocked_exception()
    {
        //Arrange
        var command = BlockUserCommand();
        var user = CreateUser();
        user.Block();
        _userRepository.GetAsync(command.UserId, Arg.Any<CancellationToken>())
            .Returns(user);
        
        //Act
        var exception = await Record.ExceptionAsync(() => Act(command));
        
        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<UserIsAlreadyBlockedException>();
        await _userRepository.Received(1).GetAsync(command.UserId, Arg.Any<CancellationToken>());
        await _userRepository.DidNotReceive().UpdateAsync(Arg.Any<User>(), Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task given_valid_command_should_block_user()
    {
        //Arrange
        var command = BlockUserCommand();
        var user = CreateUser();
        _userRepository.GetAsync(command.UserId, Arg.Any<CancellationToken>())
            .Returns(user);
        _userRepository.UpdateAsync(user, Arg.Any<CancellationToken>())
            .Returns(Task.CompletedTask);
        
        //Act
        await Act(command);
        
        //Assert
        user.IsActive.ShouldBeFalse();
        await _userRepository.Received(1).GetAsync(command.UserId, Arg.Any<CancellationToken>());
        await _userRepository.Received(1).UpdateAsync(user, Arg.Any<CancellationToken>());
        await _mediator.Received(1).Publish(Arg.Any<BlockUserEvent>(), Arg.Any<CancellationToken>());
    }


    private readonly IRequestHandler<BlockUserCommand> _handler;
    private readonly IClock _clock;
    private readonly IContext _context;
    private readonly IUserRepository _userRepository;
    private readonly IMediator _mediator;

    public BlockUserHandlerTests()
    {
        _clock = Substitute.For<IClock>();
        _context = Substitute.For<IContext>();
        _userRepository = Substitute.For<IUserRepository>();
        _mediator = Substitute.For<IMediator>();

        _handler = new BlockUserHandler(
            _context,
            _clock,
            _userRepository,
            _mediator
        );
    }

    private static BlockUserCommand BlockUserCommand() => new(Guid.NewGuid());
}