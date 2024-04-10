using MovieFlow.Modules.Movies.Application.Movies.Commands.DeleteMovie;
using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;

namespace MovieFlow.Modules.Movies.Tests.Unit.Handlers.Movies.Commands;

public class DeleteMovieHandlerTests
{
    private async Task Act(DeleteMovieCommand command) => await _handler.Handle(command, CancellationToken.None);

    [Fact]
    public async Task given_not_existing_movie_should_fail()
    {
        // Arrange
        var command = DeleteMovieCommand();
        _movieRepository.GetAsync(command.MovieId, Arg.Any<CancellationToken>())
            .Returns((Movie)null);

        // Act
        var exception = await Record.ExceptionAsync(() => Act(command));

        // Assert
        exception.ShouldBeOfType<MovieNotFoundException>();
        await _movieRepository.Received(1).GetAsync(command.MovieId, Arg.Any<CancellationToken>());
        await _movieRepository.DidNotReceiveWithAnyArgs().DeleteAsync(Arg.Any<Movie>(), Arg.Any<CancellationToken>());
    }
    
    [Fact]
    public async Task given_existing_movie_should_delete_movie()
    {
        // Arrange
        var command = DeleteMovieCommand();
        var movie = GetValidMovie();
        _movieRepository.GetAsync(command.MovieId, Arg.Any<CancellationToken>())
            .Returns(movie);

        // Act
        await Act(command);

        // Assert
        await _movieRepository.Received(1).GetAsync(command.MovieId, Arg.Any<CancellationToken>());
        await _movieRepository.Received(1).DeleteAsync(movie, Arg.Any<CancellationToken>());
    }

    private readonly IRequestHandler<DeleteMovieCommand> _handler;
    private readonly IMovieRepository _movieRepository;

    public DeleteMovieHandlerTests()
    {
        _movieRepository = Substitute.For<IMovieRepository>();
        _handler = new DeleteMovieHandler(_movieRepository);
    }

    private static DeleteMovieCommand DeleteMovieCommand() => new(Guid.NewGuid());
}