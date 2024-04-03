using MovieFlow.Modules.Movies.Application.Movies.Commands.ChangeMovieInformation;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using NSubstitute.ReturnsExtensions;
using static MovieFlow.Modules.Movies.Tests.Unit.Extensions.Extensions;

namespace MovieFlow.Modules.Movies.Tests.Unit.Handlers.Movies;

public class ChangeMovieInformationHandlerTests
{
    private async Task Act(ChangeMovieInformationCommand command)
        => await _handler.Handle(command, CancellationToken.None);

    [Fact]
    public async Task given_valid_command_should_change_movie_information()
    {
        // Arrange
        var command = ChangeMovieInformationCommand();
        var movie = GetValidMovie();
        _movieRepository.GetAsync(command.MovieId, Arg.Any<CancellationToken>())
            .Returns(movie);

        // Act
        await Act(command);

        // Assert
        await _movieRepository.Received(1).CommitAsync(Arg.Any<CancellationToken>());
        movie.Title.Value.ShouldBe(command.Title);
        movie.Description.Value.ShouldBe(command.Description);
        movie.ReleaseYear.Value.ShouldBe(command.ReleaseYear);
    }
    
    [Fact]
    public async Task given_invalid_movie_id_should_throw_movie_not_found_exception()
    {
        // Arrange
        var command = ChangeMovieInformationCommand();
        _movieRepository.GetAsync(command.MovieId, Arg.Any<CancellationToken>())
            .ReturnsNull();

        // Act
        var exception = await Record.ExceptionAsync(() => Act(command));

        // Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<MovieNotFoundException>();
    }

    private readonly IRequestHandler<ChangeMovieInformationCommand> _handler;
    private readonly IMovieRepository _movieRepository;

    public ChangeMovieInformationHandlerTests()
    {
        _movieRepository = Substitute.For<IMovieRepository>();
        _handler = new ChangeMovieInformationHandler(_movieRepository);
    }

    private static ChangeMovieInformationCommand ChangeMovieInformationCommand()
    {
        var command = new ChangeMovieInformationCommand("Title2", DateTime.Now.Year, "Description2");
        return command with { MovieId = Guid.NewGuid() };
    }
}