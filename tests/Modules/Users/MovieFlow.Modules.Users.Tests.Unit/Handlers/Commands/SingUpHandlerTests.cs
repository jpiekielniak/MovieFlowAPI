using Microsoft.AspNetCore.Identity;
using MovieFlow.Modules.Emails.Shared.Events.Users.CreateAccount;
using MovieFlow.Modules.Users.Application.Users.Commands.SignUp;
using MovieFlow.Modules.Users.Core.Users.Entities;
using MovieFlow.Modules.Users.Core.Users.Exceptions.Roles;
using MovieFlow.Modules.Users.Core.Users.Exceptions.Users;
using MovieFlow.Modules.Users.Core.Users.Repositories;

namespace MovieFlow.Modules.Users.Tests.Unit.Handlers.Commands;

public class SingUpHandlerTests
{
    private async Task<SignUpResponse> Act(SignUpCommand command)
        => await _handler.Handle(command, CancellationToken.None);

    [Fact]
    public async Task given_exists_user_should_throw_user_already_exists_exception()
    {
        //Arrange
        var command = SignUpCommand();
        _userRepository.UserExistsAsync(command.Email, command.Name, Arg.Any<CancellationToken>())
            .Returns(true);

        //Act
        var exception = await Record.ExceptionAsync(() => Act(command));

        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<UserAlreadyExistsException>();
        await _userRepository.Received(1).UserExistsAsync(command.Email, command.Name, Arg.Any<CancellationToken>());
        await _userRepository.DidNotReceive().AddAsync(Arg.Any<User>(), Arg.Any<CancellationToken>());
        await _mediator.DidNotReceive().Publish(Arg.Any<CreateAccountEvent>(), Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task given_invalid_role_should_throw_role_not_found_exception()
    {
        //Arrange
        var command = SignUpCommand();
        _userRepository.UserExistsAsync(command.Email, command.Name, Arg.Any<CancellationToken>())
            .Returns(false);
        _roleRepository.GetAsync(Arg.Any<string>(), Arg.Any<CancellationToken>())
            .ReturnsNull();

        //Act
        var exception = await Record.ExceptionAsync(() => Act(command));

        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<RoleNotFoundException>();
        await _userRepository.Received(1).UserExistsAsync(command.Email, command.Name, Arg.Any<CancellationToken>());
        await _roleRepository.Received(1).GetAsync(Arg.Any<string>(), Arg.Any<CancellationToken>());
        await _userRepository.DidNotReceive().AddAsync(Arg.Any<User>(), Arg.Any<CancellationToken>());
        await _mediator.DidNotReceive().Publish(Arg.Any<CreateAccountEvent>(), Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task given_valid_data_should_create_user()
    {
        //Arrange
        var command = SignUpCommand();
        var role = CreateRole();
        SetUpMocksForSignUp(command, role);

        //Act
        var response = await Act(command);

        //Assert
        response.ShouldNotBeNull();
        response.UserId.ShouldNotBe(Guid.Empty);
        await _userRepository.Received(1).UserExistsAsync(command.Email, command.Name, Arg.Any<CancellationToken>());
        await _roleRepository.Received(1).GetAsync(Arg.Any<string>(), Arg.Any<CancellationToken>());
        await _userRepository.Received(1).AddAsync(Arg.Any<User>(), Arg.Any<CancellationToken>());
    }


    [Fact]
    public async Task given_valid_data_should_publish_create_account_event()
    {
        //Arrange
        var command = SignUpCommand();
        var role = CreateRole();
        SetUpMocksForSignUp(command, role);

        //Act
        var response = await Act(command);

        //Assert
        response.ShouldNotBeNull();
        await _mediator.Received(1).Publish(Arg.Any<CreateAccountEvent>(), Arg.Any<CancellationToken>());
    }

    private readonly IRequestHandler<SignUpCommand, SignUpResponse> _handler;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMediator _mediator;

    public SingUpHandlerTests()
    {
        _passwordHasher = Substitute.For<IPasswordHasher<User>>();
        _roleRepository = Substitute.For<IRoleRepository>();
        _userRepository = Substitute.For<IUserRepository>();
        _mediator = Substitute.For<IMediator>();

        _handler = new SignUpHandler(
            _passwordHasher,
            _roleRepository,
            _userRepository,
            _mediator
        );
    }

    private static SignUpCommand SignUpCommand()
        => new("User123", "example@email.com");

    private void SetUpMocksForSignUp(SignUpCommand command, Role role)
    {
        _userRepository.UserExistsAsync(command.Email, command.Name, Arg.Any<CancellationToken>())
            .Returns(false);
        _roleRepository.GetAsync(Arg.Any<string>(), Arg.Any<CancellationToken>())
            .Returns(role);
        _userRepository.AddAsync(Arg.Any<User>(), Arg.Any<CancellationToken>())
            .Returns(Task.CompletedTask);
        _passwordHasher.HashPassword(default, Arg.Any<string>())
            .Returns("hashed_password_for_test");
    }
}