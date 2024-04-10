using MovieFlow.Modules.Movies.Application.Reviews.Commands.DeleteReview;
using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Reviews;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Shared.Abstractions.Contexts;
using NSubstitute.ReturnsExtensions;
using static MovieFlow.Modules.Movies.Tests.Unit.Extensions.Extensions;

namespace MovieFlow.Modules.Movies.Tests.Unit.Handlers.Reviews.Commands;

public class DeleteReviewHandlerTests
{
    private async Task Act(DeleteReviewCommand command)
        => await _handler.Handle(command, CancellationToken.None);

    [Fact]
    public async Task given_invalid_movieId_should_throw_movie_not_found_exception()
    {
        // Arrange
        var command = DeleteReviewCommand(Guid.NewGuid(), Guid.NewGuid());
        _movieRepository.GetAsync(command.MovieId, Arg.Any<CancellationToken>())
            .ReturnsNull();

        // Act
        var exception = await Record.ExceptionAsync(() => Act(command));

        // Assert
        await _movieRepository.Received(1).GetAsync(command.MovieId, Arg.Any<CancellationToken>());
        await _movieRepository.DidNotReceive().DeleteAsync(Arg.Any<Movie>(), Arg.Any<CancellationToken>());
        exception.ShouldBeOfType<MovieNotFoundException>();
        exception.ShouldNotBeNull();
    }

    [Fact]
    public async Task given_invalid_reviewId_should_throw_review_not_found_exception()
    {
        // Arrange
        var command = DeleteReviewCommand(Guid.NewGuid(), Guid.NewGuid());
        var movie = GetValidMovie();
        _movieRepository.GetAsync(command.MovieId, Arg.Any<CancellationToken>())
            .Returns(movie);
        _reviewRepository.GetAsync(command.ReviewId, Arg.Any<CancellationToken>())
            .ReturnsNull();

        // Act
        var exception = await Record.ExceptionAsync(() => Act(command));

        // Assert
        await _movieRepository.Received(1).GetAsync(command.MovieId, Arg.Any<CancellationToken>());
        await _reviewRepository.Received(1).GetAsync(command.ReviewId, Arg.Any<CancellationToken>());
        await _reviewRepository.DidNotReceive().DeleteAsync(Arg.Any<Review>(), Arg.Any<CancellationToken>());
        exception.ShouldBeOfType<ReviewNotFoundException>();
        exception.ShouldNotBeNull();
    }

    [Fact]
    public async Task given_valid_data_should_delete_review()
    {
        //Arrange
        var command = DeleteReviewCommand();
        var movie = GetValidMovie();
        var review = CreateReview();
        _movieRepository.GetAsync(command.MovieId, Arg.Any<CancellationToken>())
            .Returns(movie);
        _reviewRepository.GetAsync(command.ReviewId, Arg.Any<CancellationToken>())
            .Returns(review);
        _context.Identity.Id.Returns(review.UserId);
        _reviewRepository.DeleteAsync(review, Arg.Any<CancellationToken>())
            .Returns(Task.CompletedTask);

        //Act
        await Act(command);

        //Assert
        await _movieRepository.Received(1).GetAsync(command.MovieId, Arg.Any<CancellationToken>());
        await _reviewRepository.Received(1).GetAsync(command.ReviewId, Arg.Any<CancellationToken>());
        await _reviewRepository.Received(1).DeleteAsync(review, Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task given_review_does_not_belong_to_movie_should_throw_review_does_not_belong_to_movie_exception()
    {
        //Arrange
        var movie = GetValidMovie();
        var review = CreateReview();
        var command = DeleteReviewCommand(movie.Id, review.Id);
        _movieRepository.GetAsync(command.MovieId, Arg.Any<CancellationToken>())
            .Returns(movie);
        _reviewRepository.GetAsync(command.ReviewId, Arg.Any<CancellationToken>())
            .Returns(review);
        
        //Act
        var exception = await Record.ExceptionAsync(() => Act(command));
        
        //Assert
        await _movieRepository.Received(1).GetAsync(command.MovieId, Arg.Any<CancellationToken>());
        await _reviewRepository.Received(1).GetAsync(command.ReviewId, Arg.Any<CancellationToken>());
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<ReviewDoesNotBelongToMovieException>();
    }
    
    [Fact]
    public async Task given_review_does_not_belong_to_user_should_throw_review_does_not_belong_to_user_exception()
    {
        //Arrange
        var movie = GetValidMovie();
        var review = CreateReview();
        var command = DeleteReviewCommand();
        _movieRepository.GetAsync(command.MovieId, Arg.Any<CancellationToken>())
            .Returns(movie);
        _reviewRepository.GetAsync(command.ReviewId, Arg.Any<CancellationToken>())
            .Returns(review);
        _context.Identity.Id.Returns(Guid.NewGuid());
        
        //Act
        var exception = await Record.ExceptionAsync(() => Act(command));
        
        //Assert
        await _movieRepository.Received(1).GetAsync(command.MovieId, Arg.Any<CancellationToken>());
        await _reviewRepository.Received(1).GetAsync(command.ReviewId, Arg.Any<CancellationToken>());
        await _reviewRepository.DidNotReceive().DeleteAsync(review, Arg.Any<CancellationToken>());
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<ReviewDoesNotBelongToUserException>();
    }

    private readonly IRequestHandler<DeleteReviewCommand> _handler;
    private readonly IMovieRepository _movieRepository;
    private readonly IReviewRepository _reviewRepository;
    private readonly IContext _context;

    public DeleteReviewHandlerTests()
    {
        _movieRepository = Substitute.For<IMovieRepository>();
        _reviewRepository = Substitute.For<IReviewRepository>();
        _context = Substitute.For<IContext>();
        _handler = new DeleteReviewHandler(
            _context,
            _movieRepository,
            _reviewRepository
        );
    }

    private static DeleteReviewCommand DeleteReviewCommand(Guid movieId = default, 
        Guid reviewId = default)
        => new(movieId, reviewId);
}