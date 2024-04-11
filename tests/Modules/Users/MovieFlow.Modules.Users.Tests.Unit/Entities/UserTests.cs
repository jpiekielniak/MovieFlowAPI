using MovieFlow.Modules.Users.Core.Users.Entities;
using MovieFlow.Shared.Abstractions.Kernel;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Name.Exceptions;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Password.Exceptions;
using static MovieFlow.Modules.Users.Tests.Unit.Extensions.Extensions;

namespace MovieFlow.Modules.Users.Tests.Unit.Entities;

public class UserTests
{
    [Fact]
    public void given_valid_user_should_succeed()
    {
        //Act
        var user = CreateUser();

        //Assert
        user.ShouldNotBeNull();
        user.ShouldBeOfType<User>();
        user.Id.ShouldBeAssignableTo<Guid>();
        user.State.ShouldBe(EntityState.Added);
    }

    [Fact]
    public void given_invalid_email_should_fail()
    {
        //Arrange
        const string name = "ExampleUser";
        const string email = null;
        const string password = "ExamplePassword";
        var role = new Role();

        //Act
        var exception = Record.Exception(() => User.Create(name, email, password, role));

        //Assert
        exception.ShouldNotBeNull();
    }

    [Fact]
    public void given_invalid_name_should_fail()
    {
        //Arrange
        const string name = null;
        const string email = "example@email.com";
        const string password = "ExamplePassword";
        var role = new Role();

        //Act
        var exception = Record.Exception(() => User.Create(name, email, password, role));

        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<InvalidNameException>();
    }

    [Fact]
    public void given_new_password_should_set_password()
    {
        //Arrange
        var user = CreateUser();
        const string newPassword = "NewPassword123";

        //Act
        user.SetPassword(newPassword, DateTimeOffset.Now);

        //Assert
        user.Password.Value.ShouldBe(newPassword);
        user.State.ShouldBe(EntityState.Modified);
    }

    [Fact]
    public void given_invalid_new_password_should_fail()
    {
        //Arrange
        var user = CreateUser();
        const string newPassword = null;

        //Act
        var exception = Record.Exception(() => user.SetPassword(newPassword, DateTimeOffset.Now));

        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<InvalidPasswordException>();
    }

    [Fact]
    public void given_blocked_user_should_block()
    {
        //Arrange
        var user = CreateUser();

        //Act
        user.Block();

        //Assert
        user.IsActive.ShouldBe(false);
        user.State.ShouldBe(EntityState.Modified);
    }

    [Fact]
    public void given_unblocked_user_should_unblock()
    {
        //Arrange
        var user = CreateUser();
        user.Block();

        //Act
        user.Unblock();

        //Assert
        user.IsActive.ShouldBe(true);
        user.State.ShouldBe(EntityState.Modified);
    }
}