using MovieFlow.Modules.Users.Application.Users.Commands.SignIn;
using MovieFlow.Modules.Users.Core.Users.Entities;
using MovieFlow.Modules.Users.Core.Users.Exceptions.Users;
using MovieFlow.Modules.Users.Core.Users.Repositories;
using MovieFlow.Modules.Users.Tests.Unit.Helpers;

namespace MovieFlow.Modules.Users.Tests.Unit.Handlers.Commands;

public class SignInHandlerTests
{
    private async Task<SignInResponse> Act(SignInCommand command)
        => await _handler.Handle(command, CancellationToken.None);

    [Fact]
    public async Task given_invalid_email_should_throw_invalid_credentials_exception()
    {
        //Arrange
        var command = SignInCommand();
        _userRepository.GetByEmailAsync(command.Email, Arg.Any<CancellationToken>()).ReturnsNull();

        //Act
        var exception = await Record.ExceptionAsync(() => Act(command));

        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<InvalidCredentialsException>();
        await _userRepository.Received(1).GetByEmailAsync(command.Email, Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task given_inactive_user_should_throw_user_not_active_exception()
    {
        //Arrange
        var command = SignInCommand();
        var user = CreateUser();
        user.Block();
        _userRepository.GetByEmailAsync(command.Email, Arg.Any<CancellationToken>())
            .Returns(user);

        //Act
        var exception = await Record.ExceptionAsync(() => Act(command));

        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<UserNotActiveException>();
        await _userRepository.Received(1).GetByEmailAsync(command.Email, Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task given_invalid_password_should_throw_invalid_credentials_exception()
    {
        var command = SignInCommand();
        var user = CreateUser();
        _userRepository.GetByEmailAsync(command.Email, Arg.Any<CancellationToken>())
            .Returns(user);
        _passwordHasher.VerifyHashedPassword(user, user.Password, command.Password)
            .Returns(PasswordVerificationResult.Failed);

        //Act
        var exception = await Record.ExceptionAsync(() => Act(command));

        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<InvalidCredentialsException>();
        await _userRepository.Received(1).GetByEmailAsync(command.Email, Arg.Any<CancellationToken>());
        _passwordHasher.Received(1).VerifyHashedPassword(user, user.Password, command.Password);
    }

    [Fact]
    public async Task given_valid_credentials_should_return_sign_in_response()
    {
        //Arrange
        var command = SignInCommand();
        var user = CreateUser();
        var token = JwtHelper.CreateToken(user.Id.ToString(), user.Role.Name);
        _userRepository.GetByEmailAsync(command.Email, Arg.Any<CancellationToken>())
            .Returns(user);
        _passwordHasher.VerifyHashedPassword(user, user.Password, command.Password)
            .Returns(PasswordVerificationResult.Success);
        _authManager.CreateToken(user.Id.ToString(), user.Role.Name,
                claims: Arg.Any<Dictionary<string, IEnumerable<string>>>())
            .Returns(token);

        //Act
        var response = await Act(command);

        //Assert
        response.ShouldNotBeNull();
        response.Token.ShouldNotBeNullOrWhiteSpace();
        response.Token.ShouldBe(token.AccessToken);
        await _userRepository.Received(1).GetByEmailAsync(command.Email, Arg.Any<CancellationToken>());
        _passwordHasher.Received(1).VerifyHashedPassword(user, user.Password, command.Password);
        _authManager.Received(1).CreateToken(user.Id.ToString(), user.Role.Name,
            claims: Arg.Any<Dictionary<string, IEnumerable<string>>>());
    }

    private readonly IRequestHandler<SignInCommand, SignInResponse> _handler;
    private readonly IUserRepository _userRepository;
    private readonly IAuthManager _authManager;
    private readonly IPasswordHasher<User> _passwordHasher;

    public SignInHandlerTests()
    {
        _userRepository = Substitute.For<IUserRepository>();
        _authManager = Substitute.For<IAuthManager>();
        _passwordHasher = Substitute.For<IPasswordHasher<User>>();

        _handler = new SignInHandler(
            _userRepository,
            _authManager,
            _passwordHasher
        );
    }

    private static SignInCommand SignInCommand()
        => new("example@email.com", "password");
}