using MovieFlow.Modules.Movies.Application.Reviews.Commands.AddReview;
using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Shared.Abstractions.Contexts;
using NSubstitute.ReturnsExtensions;
using static MovieFlow.Modules.Movies.Tests.Unit.Extensions.Extensions;
namespace MovieFlow.Modules.Movies.Tests.Unit.Handlers.Reviews.Commands;

public class AddReviewHandlerTests
{
    private async Task<AddReviewResponse> Act(AddReviewCommand command)
        => await _handler.Handle(command, CancellationToken.None);
    
    [Fact]
    public async Task given_valid_data_to_add_review_should_succeed()
    {
        //Arrange
        var command = AddReviewCommand();
        var movie = GetValidMovie();
        _movieRepository.GetAsync(command.MovieId, Arg.Any<CancellationToken>())
            .Returns(movie);
        _reviewRepository.AddAsync(Arg.Any<Review>(), Arg.Any<CancellationToken>())
            .Returns(Task.CompletedTask);
        
        //Act
        var response = await Act(command);
        
        //Assert
        await _movieRepository.Received(1).GetAsync(command.MovieId, Arg.Any<CancellationToken>());
        await _reviewRepository.Received(1).AddAsync(Arg.Any<Review>(), Arg.Any<CancellationToken>());
        response.ReviewId.ShouldBeOfType<Guid>();
    }
    
    [Fact]
    public async Task given_invalid_movie_id_should_throw_movie_not_found_exception()
    {
        //Arrange
        var command = AddReviewCommand();
        _movieRepository.GetAsync(command.MovieId, Arg.Any<CancellationToken>())
            .ReturnsNull();
        
        //Act
        var exception = await Record.ExceptionAsync(() => Act(command));
        
        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<MovieNotFoundException>();
        await _movieRepository.Received(1).GetAsync(command.MovieId, Arg.Any<CancellationToken>());
        await _reviewRepository.DidNotReceive().AddAsync(Arg.Any<Review>(), Arg.Any<CancellationToken>());
    } 

    private readonly IRequestHandler<AddReviewCommand, AddReviewResponse> _handler;
    private readonly IMovieRepository _movieRepository;
    private readonly IReviewRepository _reviewRepository;

    public AddReviewHandlerTests()
    {
        _movieRepository = Substitute.For<IMovieRepository>();
        _reviewRepository = Substitute.For<IReviewRepository>();
        var context = Substitute.For<IContext>();
        _handler = new AddReviewHandler(
            context,
            _movieRepository,
            _reviewRepository
        );
    }

    private static AddReviewCommand AddReviewCommand()
        => new("Title", "Content", 5.0f);
}