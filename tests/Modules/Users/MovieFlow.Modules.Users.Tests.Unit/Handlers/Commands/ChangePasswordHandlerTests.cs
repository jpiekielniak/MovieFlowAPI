using MovieFlow.Modules.Emails.Shared.Events.Users.ChangePassword;
using MovieFlow.Modules.Users.Application.Users.Commands.ChangePassword;
using MovieFlow.Modules.Users.Core.Users.Entities;
using MovieFlow.Modules.Users.Core.Users.Exceptions.Users;
using MovieFlow.Modules.Users.Core.Users.Repositories;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Password.Exceptions;

namespace MovieFlow.Modules.Users.Tests.Unit.Handlers.Commands;

public class ChangePasswordHandlerTests
{
    private async Task Act(ChangePasswordCommand command)
        => await _handler.Handle(command, CancellationToken.None);

    [Fact]
    public async Task given_valid_command_should_change_password()
    {
        // Arrange
        var command = ChangePasswordCommand();
        var user = CreateUser();
        _context.Identity.Id.Returns(user.Id);
        _userRepository.GetAsync(_context.Identity.Id, Arg.Any<CancellationToken>())
            .Returns(user);
        _userRepository.UpdateAsync(user, Arg.Any<CancellationToken>())
            .Returns(Task.CompletedTask);
        _passwordHasher.VerifyHashedPassword(default, user.Password, command.CurrentPassword)
            .Returns(PasswordVerificationResult.Success);
        _passwordHasher.HashPassword(default, command.NewPassword).Returns("hashed_password_for_test");
        _clock.CurrentDateTimeOffset().Returns(DateTimeOffset.Now);

        // Act
        await Act(command);

        // Assert
        await _userRepository.Received(1).GetAsync(_context.Identity.Id, Arg.Any<CancellationToken>());
        await _userRepository.Received(1).UpdateAsync(user, Arg.Any<CancellationToken>());
        await _mediator.Received(1).Publish(Arg.Any<ChangePasswordEvent>(), Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task given_invalid_current_password_should_throw_invalid_password_exception()
    {
        // Arrange
        var command = ChangePasswordCommand();
        var user = CreateUser();
        _context.Identity.Id.Returns(user.Id);
        _userRepository.GetAsync(_context.Identity.Id, Arg.Any<CancellationToken>())
            .Returns(user);
        _passwordHasher.VerifyHashedPassword(default, user.Password, command.CurrentPassword)
            .Returns(PasswordVerificationResult.Failed);

        // Act
        var exception = await Record.ExceptionAsync(() => Act(command));

        // Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<InvalidPasswordException>();
        await _userRepository.Received(1).GetAsync(_context.Identity.Id, Arg.Any<CancellationToken>());
        await _userRepository.DidNotReceive().UpdateAsync(Arg.Any<User>(), Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task given_invalid_confirm_password_should_throw_passwords_do_not_match_exception()
    {
        // Arrange
        var command = new ChangePasswordCommand(CurrentPassword, "test", "test2");
        var user = CreateUser();
        _context.Identity.Id.Returns(user.Id);
        _userRepository.GetAsync(_context.Identity.Id, Arg.Any<CancellationToken>())
            .Returns(user);
        _passwordHasher.VerifyHashedPassword(default, user.Password, command.CurrentPassword)
            .Returns(PasswordVerificationResult.Success);

        // Act
        var exception = await Record.ExceptionAsync(() => Act(command));

        // Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<PasswordsDoNotMatchException>();
        await _userRepository.Received(1).GetAsync(_context.Identity.Id, Arg.Any<CancellationToken>());
        await _userRepository.DidNotReceive().UpdateAsync(Arg.Any<User>(), Arg.Any<CancellationToken>());
    }

    private readonly IRequestHandler<ChangePasswordCommand> _handler;
    private readonly IClock _clock;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IContext _context;
    private readonly IMediator _mediator;

    public ChangePasswordHandlerTests()
    {
        _clock = Substitute.For<IClock>();
        _userRepository = Substitute.For<IUserRepository>();
        _passwordHasher = Substitute.For<IPasswordHasher<User>>();
        _context = Substitute.For<IContext>();
        _mediator = Substitute.For<IMediator>();

        _handler = new ChangePasswordHandler(
            _clock,
            _userRepository,
            _passwordHasher,
            _context,
            _mediator
        );
    }

    private const string CurrentPassword = "Password123";
    private const string NewPassword = "newPassword";
    private const string ConfirmNewPassword = "newPassword";

    private static ChangePasswordCommand ChangePasswordCommand()
        => new(CurrentPassword, NewPassword, ConfirmNewPassword);
}