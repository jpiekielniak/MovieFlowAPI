using MovieFlow.Modules.Newsletters.Core.Newsletters.Entities;
using MovieFlow.Shared.Abstractions.Exceptions;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Email;

namespace MovieFlow.Modules.Newsletters.Tests.Unit.Entities;

public class EmailSubscriptionTests
{
    private EmailSubscription Act(Email email)
        => EmailSubscription.Create(email);

    [Fact]
    public void given_valid_email_should_create_email_subscription()
    {
        // Arrange
        const string email = "example@email.com";

        //Act
        var emailSubscription = Act(email);
        
        //Assert
        emailSubscription.ShouldNotBeNull();
        emailSubscription.Email.Value.ShouldBe(email);
    }

    [Fact]
    public void given_null_email_should_throw_invalid_email_exception()
    {
        //Arrange
        const string email = null;
        
        //Act
        var exception = Record.Exception(() => Act(email));
        
        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeAssignableTo<MovieFlowException>();
    }
}