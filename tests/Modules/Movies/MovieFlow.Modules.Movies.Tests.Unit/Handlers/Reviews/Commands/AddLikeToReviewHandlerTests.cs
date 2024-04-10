using MovieFlow.Modules.Movies.Application.Reviews.Commands.AddLikeToReview;
using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Reviews;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;

namespace MovieFlow.Modules.Movies.Tests.Unit.Handlers.Reviews.Commands;

public class AddLikeToReviewHandlerTests
{
    private async Task Act(AddLikeToReviewCommand command)
        => await _handler.Handle(command, CancellationToken.None);

    [Fact]
    public async Task given_invalid_movieId_should_throw_movie_not_found_exception()
    {
        //Arrange
        var command = AddLikeToReviewCommand();
        _movieRepository.GetAsync(command.MovieId, Arg.Any<CancellationToken>())
            .ReturnsNull();
        
        //Act
        var exception = await Record.ExceptionAsync(() => Act(command));
        
        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<MovieNotFoundException>();
        await _movieRepository.Received(1).GetAsync(command.MovieId, Arg.Any<CancellationToken>());
        await _reviewRepository.DidNotReceive().GetAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>());
        await _likeRepository.DidNotReceive().AddAsync(Arg.Any<Like>(), Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task given_invalid_reviewId_should_throw_review_not_found_exception()
    {
        //Arrange
        var command = AddLikeToReviewCommand();
        var movie = GetValidMovie();
        _movieRepository.GetAsync(command.MovieId, Arg.Any<CancellationToken>())
            .Returns(movie);
        _reviewRepository.GetAsync(command.ReviewId, Arg.Any<CancellationToken>())
            .ReturnsNull();
        
        //Act
        var exception = await Record.ExceptionAsync(() => Act(command));
        
        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<ReviewNotFoundException>();
        await _movieRepository.Received(1).GetAsync(command.MovieId, Arg.Any<CancellationToken>());
        await _reviewRepository.Received(1).GetAsync(command.ReviewId, Arg.Any<CancellationToken>());
        await _likeRepository.DidNotReceive().AddAsync(Arg.Any<Like>(), Arg.Any<CancellationToken>());
    }
    
    [Fact]
    public async Task given_existing_like_for_review_should_throw_like_for_review_already_exists_exception()
    {
        //Arrange
        var command = AddLikeToReviewCommand();
        var movie = GetValidMovie();
        var review = CreateReview();
        review.Likes.Add(Like.Create(review, review.UserId, true));
        _context.Identity.Id.Returns(review.UserId);
        _movieRepository.GetAsync(command.MovieId, Arg.Any<CancellationToken>())
            .Returns(movie);
        _reviewRepository.GetAsync(command.ReviewId, Arg.Any<CancellationToken>())
            .Returns(review);
        
        //Act
        var exception = await Record.ExceptionAsync(() => Act(command));
        
        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<LikeForReviewAlreadyExistsException>();
        await _movieRepository.Received(1).GetAsync(command.MovieId, Arg.Any<CancellationToken>());
        await _reviewRepository.Received(1).GetAsync(command.ReviewId, Arg.Any<CancellationToken>());
        await _likeRepository.DidNotReceive().AddAsync(Arg.Any<Like>(), Arg.Any<CancellationToken>());
    }
    
    [Fact]
    public async Task given_valid_request_should_add_like_to_review()
    {
        //Arrange
        var command = AddLikeToReviewCommand();
        var movie = GetValidMovie();
        var review = CreateReview();
        _context.Identity.Id.Returns(review.UserId);
        _movieRepository.GetAsync(command.MovieId, Arg.Any<CancellationToken>())
            .Returns(movie);
        _reviewRepository.GetAsync(command.ReviewId, Arg.Any<CancellationToken>())
            .Returns(review);
        
        //Act
        await Act(command);
        
        //Assert
        await _movieRepository.Received(1).GetAsync(command.MovieId, Arg.Any<CancellationToken>());
        await _reviewRepository.Received(1).GetAsync(command.ReviewId, Arg.Any<CancellationToken>());
        await _likeRepository.Received(1).AddAsync(Arg.Any<Like>(), Arg.Any<CancellationToken>());
    }

    private readonly IRequestHandler<AddLikeToReviewCommand> _handler;
    private readonly IMovieRepository _movieRepository;
    private readonly IReviewRepository _reviewRepository;
    private readonly ILikeRepository _likeRepository;
    private readonly IContext _context;

    public AddLikeToReviewHandlerTests()
    {
        _movieRepository = Substitute.For<IMovieRepository>();
        _reviewRepository = Substitute.For<IReviewRepository>();
        _likeRepository = Substitute.For<ILikeRepository>();
        _context = Substitute.For<IContext>();

        _handler = new AddLikeToReviewHandler(
            _movieRepository,
            _reviewRepository,
            _likeRepository,
            _context
        );
    }

    private static AddLikeToReviewCommand AddLikeToReviewCommand(
        bool isPositive = true)
    {
        var command = new AddLikeToReviewCommand(isPositive);

        return command with
        {
            MovieId = Guid.NewGuid(),
            ReviewId = Guid.NewGuid()
        };
    }
}