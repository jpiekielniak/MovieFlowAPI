using MovieFlow.Modules.Movies.Application.Reviews.Commands.ChangeReviewInformation;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Reviews;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;

namespace MovieFlow.Modules.Movies.Tests.Unit.Handlers.Reviews.Commands;

public class ChangeReviewInformationHandlerTests
{
    private async Task Act(ChangeReviewInformationCommand command)
        => await _handler.Handle(command, CancellationToken.None);

    [Fact]
    public async Task given_invalid_movie_id_should_throw_movie_not_found_exception()
    {
        //Arrange
        var command = ChangeReviewInformationCommand();
        _movieRepository.GetAsync(command.MovieId, Arg.Any<CancellationToken>())
            .ReturnsNull();
        
        //Act
        var exception = await Record.ExceptionAsync(() => Act(command));
        
        //Assert
        await _reviewRepository.DidNotReceiveWithAnyArgs().GetAsync(default, default);
        await _reviewRepository.DidNotReceiveWithAnyArgs().CommitAsync(default);
        await _movieRepository.Received(1).GetAsync(command.MovieId, Arg.Any<CancellationToken>());
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<MovieNotFoundException>();
    }

    [Fact]
    public async Task given_invalid_review_id_should_throw_review_not_found_exception()
    {
        //Arrange
        var command = ChangeReviewInformationCommand();
        var movie = GetValidMovie();
        _movieRepository.GetAsync(command.MovieId, Arg.Any<CancellationToken>())
            .Returns(movie);
        _reviewRepository.GetAsync(command.ReviewId, Arg.Any<CancellationToken>())
            .ReturnsNull();
        
        //Act
        var exception = await Record.ExceptionAsync(() => Act(command));
        
        //Assert
        await _reviewRepository.Received(1).GetAsync(command.ReviewId, Arg.Any<CancellationToken>());
        await _reviewRepository.DidNotReceiveWithAnyArgs().CommitAsync(default);
        await _movieRepository.Received(1).GetAsync(command.MovieId, Arg.Any<CancellationToken>());
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<ReviewNotFoundException>();
    }
    
    [Fact]
    public async Task given_valid_data_should_change_review_information()
    {
        //Arrange
        var command = ChangeReviewInformationCommand();
        var movie = GetValidMovie();
        var review = CreateReview();
        _movieRepository.GetAsync(command.MovieId, Arg.Any<CancellationToken>())
            .Returns(movie);
        _reviewRepository.GetAsync(command.ReviewId, Arg.Any<CancellationToken>())
            .Returns(review);
        _context.Identity.Id.Returns(review.UserId);
        
        //Act
        await Act(command);
        
        //Assert
        await _reviewRepository.Received(1).CommitAsync(Arg.Any<CancellationToken>());
        await _reviewRepository.Received(1).GetAsync(command.ReviewId, Arg.Any<CancellationToken>());
        await _movieRepository.Received(1).GetAsync(command.MovieId, Arg.Any<CancellationToken>());
        review.Title.Value.ShouldBe(command.Title);
        review.Content.Value.ShouldBe(command.Content);
        review.Rating.Value.ShouldBe(command.Rating);
    }

    private readonly IRequestHandler<ChangeReviewInformationCommand> _handler;
    private readonly IReviewRepository _reviewRepository;
    private readonly IMovieRepository _movieRepository;
    private readonly IContext _context;

    public ChangeReviewInformationHandlerTests()
    {
        _reviewRepository = Substitute.For<IReviewRepository>();
        _movieRepository = Substitute.For<IMovieRepository>();
        _context = Substitute.For<IContext>();
        _handler = new ChangeReviewInformationHandler(
            _movieRepository,
            _reviewRepository,
            _context);
    }

    private static ChangeReviewInformationCommand ChangeReviewInformationCommand()
    {
        var command = new ChangeReviewInformationCommand("title", "content", 2.0f)
        {
            MovieId = Guid.NewGuid(),
            ReviewId = Guid.NewGuid()
        };
        
        return command;
    }
}