using MovieFlow.Modules.Emails.Shared.Events.Newsletters.EmailSubscriptions.SubscribeEmailNewsletter;
using MovieFlow.Modules.Newsletters.Application.EmailSubscriptions.Commands.SubscribeEmailNewsletter;
using MovieFlow.Modules.Newsletters.Core.Newsletters.Entities;
using MovieFlow.Modules.Newsletters.Core.Newsletters.Exceptions.EmailSubscriptions;
using MovieFlow.Modules.Newsletters.Core.Newsletters.Repositories;
using MovieFlow.Shared.Abstractions.Time;

namespace MovieFlow.Modules.Newsletters.Tests.Unit.Handlers.EmailSubscriptions.Commands;

public class SubscribeEmailNewsletterHandlerTests
{
    private async Task Act(SubscribeEmailNewsletterCommand command)
        => await _handler.Handle(command, CancellationToken.None);

    [Fact]
    public async Task given_existing_email_subscription_should_throw_email_subscription_already_exists_exception()
    {
        //Arrange
        var command = SubscribeEmailNewsletterCommand();
        _emailSubscriptionsRepository.CheckEmailExistsAsync(command.Email, Arg.Any<CancellationToken>())
            .Returns(true);
        
        //Act
        var exception = await Record.ExceptionAsync(() => Act(command));
        
        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<EmailSubscriptionAlreadyExistsException>();
    }
    
    [Fact]
    public async Task given_not_existing_email_subscription_should_subscribe_email_newsletter()
    {
        //Arrange
        var command = SubscribeEmailNewsletterCommand();
        _emailSubscriptionsRepository.CheckEmailExistsAsync(command.Email, Arg.Any<CancellationToken>())
            .Returns(false);
        _emailSubscriptionsRepository.AddAsync(Arg.Any<EmailSubscription>(), Arg.Any<CancellationToken>())
            .Returns(Task.CompletedTask);
        _mediator.Publish(Arg.Any<SubscribedEmailNewsletterEvent>(), Arg.Any<CancellationToken>())
            .Returns(Task.CompletedTask);
        
        //Act
        await Act(command);
        
        //Assert
        await _emailSubscriptionsRepository.Received(1).AddAsync(Arg.Any<EmailSubscription>(), Arg.Any<CancellationToken>());
        await _mediator.Received(1).Publish(Arg.Any<SubscribedEmailNewsletterEvent>(), Arg.Any<CancellationToken>());
        await _emailSubscriptionsRepository.Received(1).CheckEmailExistsAsync(command.Email, Arg.Any<CancellationToken>());
        _clock.Received(1).CurrentDateTimeOffset();
    }   
    

    private readonly IRequestHandler<SubscribeEmailNewsletterCommand> _handler;
    private readonly IEmailSubscriptionsRepository _emailSubscriptionsRepository;
    private readonly IMediator _mediator;
    private readonly IClock _clock;

    public SubscribeEmailNewsletterHandlerTests()
    {
        _emailSubscriptionsRepository = Substitute.For<IEmailSubscriptionsRepository>();
        _mediator = Substitute.For<IMediator>();
        _clock = Substitute.For<IClock>();

        _handler = new SubscribeEmailNewsletterHandler(
            _emailSubscriptionsRepository,
            _mediator,
            _clock
        );
    }
    
    private static SubscribeEmailNewsletterCommand SubscribeEmailNewsletterCommand()
        => new("example@email.com");
}