using MovieFlow.Modules.Emails.Shared.Events.Newsletters.EmailSubscriptions.UnSubscribeEmailNewsletter;
using MovieFlow.Modules.Newsletters.Application.EmailSubscriptions.Commands.UnSubscribeEmailNewsletter;
using MovieFlow.Modules.Newsletters.Core.Newsletters.Entities;
using MovieFlow.Modules.Newsletters.Core.Newsletters.Exceptions.EmailSubscriptions;
using MovieFlow.Modules.Newsletters.Core.Newsletters.Repositories;
using MovieFlow.Shared.Abstractions.Time;

namespace MovieFlow.Modules.Newsletters.Tests.Unit.Handlers.EmailSubscriptions.Commands;

public class UnSubscribeEmailNewsletterHandlerTests
{
     private async Task Act(UnSubscribeEmailNewsletterCommand command)
        => await _handler.Handle(command, CancellationToken.None);

    [Fact]
    public async Task given_existing_email_subscription_should_delete_subscription()
    {
        //Arrange
        var command = UnSubscribeEmailNewsletterCommand();
        var email = CreateEmailSubscription();
        _emailSubscriptionsRepository.GetAsync(command.Email, Arg.Any<CancellationToken>())
            .Returns(email);
        _emailSubscriptionsRepository.DeleteAsync(email, Arg.Any<CancellationToken>())
            .Returns(Task.CompletedTask);
        _mediator.Publish(Arg.Any<UnSubscribedEmailNewsletterEvent>(), Arg.Any<CancellationToken>())
            .Returns(Task.CompletedTask);
        
        //Act
        await Act(command);
        
        //Assert
        await _emailSubscriptionsRepository.Received(1).DeleteAsync(email, Arg.Any<CancellationToken>());
        await _mediator.Received(1).Publish(Arg.Any<UnSubscribedEmailNewsletterEvent>(), Arg.Any<CancellationToken>());
        await _emailSubscriptionsRepository.Received(1).GetAsync(command.Email, Arg.Any<CancellationToken>());
        _clock.Received(1).CurrentDateTimeOffset();
    }
    
    [Fact]
    public async Task given_not_existing_email_subscription_should_throw_email_subscription_not_found_exception()
    {
        //Arrange
        var command = UnSubscribeEmailNewsletterCommand();
        _emailSubscriptionsRepository.GetAsync(command.Email, Arg.Any<CancellationToken>())
            .ReturnsNull();
        
        //Act
        var exception = await Record.ExceptionAsync(() => Act(command));
        
        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<EmailSubscriptionNotFoundException>();
        await _emailSubscriptionsRepository.Received(1).GetAsync(command.Email, Arg.Any<CancellationToken>());
        await _emailSubscriptionsRepository.DidNotReceive().DeleteAsync(Arg.Any<EmailSubscription>(), Arg.Any<CancellationToken>());
        await _mediator.DidNotReceive().Publish(Arg.Any<UnSubscribedEmailNewsletterEvent>(), Arg.Any<CancellationToken>());
    }   
    

    private readonly IRequestHandler<UnSubscribeEmailNewsletterCommand> _handler;
    private readonly IEmailSubscriptionsRepository _emailSubscriptionsRepository;
    private readonly IMediator _mediator;
    private readonly IClock _clock;

    public UnSubscribeEmailNewsletterHandlerTests()
    {
        _emailSubscriptionsRepository = Substitute.For<IEmailSubscriptionsRepository>();
        _mediator = Substitute.For<IMediator>();
        _clock = Substitute.For<IClock>();

        _handler = new UnSubscribeEmailNewsletterHandler(
            _emailSubscriptionsRepository,
            _mediator,
            _clock
        );
    }
    
    private static UnSubscribeEmailNewsletterCommand UnSubscribeEmailNewsletterCommand()
        => new("example@email.com");

    private static EmailSubscription CreateEmailSubscription()
        => EmailSubscription.Create("example@email.com");
}