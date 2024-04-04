using MovieFlow.Modules.Movies.Application.Genres.Commands.DeleteGenre;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Genres;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using NSubstitute.ReturnsExtensions;
using static MovieFlow.Modules.Movies.Tests.Unit.Extensions.Extensions;
namespace MovieFlow.Modules.Movies.Tests.Unit.Handlers.Genres.Commands;

public class DeleteGenreHandlerTests
{
    private async Task Act(DeleteGenreCommand command)
        => await _handler.Handle(command, CancellationToken.None);
    
    [Fact]
    public async Task given_valid_genre_id_should_delete_genre()
    {
        // Arrange
        var genre = CreateGenre();
        var command = new DeleteGenreCommand(genre.Id);
        _genreRepository.GetAsync(command.GenreId, Arg.Any<CancellationToken>())
            .Returns(genre);
        _genreRepository.DeleteAsync(genre, Arg.Any<CancellationToken>())
            .Returns(Task.CompletedTask);
        
        // Act
        await Act(command);
        
        // Assert
        await _genreRepository.Received(1).GetAsync(command.GenreId, Arg.Any<CancellationToken>());
        await _genreRepository.Received(1).DeleteAsync(genre, Arg.Any<CancellationToken>());
    }
    
    [Fact]
    public async Task given_invalid_genre_id_should_throw_genre_not_found_exception()
    {
        // Arrange
        var command = new DeleteGenreCommand(Guid.NewGuid());
        _genreRepository.GetAsync(command.GenreId, Arg.Any<CancellationToken>())
            .ReturnsNull();
        
        // Act
        var exception = await Record.ExceptionAsync(() => Act(command));
        
        // Assert
        exception.ShouldBeOfType<GenreNotFoundException>();
        await _genreRepository.Received(1).GetAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>());
    }


    private readonly IRequestHandler<DeleteGenreCommand> _handler;
    private readonly IGenreRepository _genreRepository;

    public DeleteGenreHandlerTests()
    {
        _genreRepository = Substitute.For<IGenreRepository>();
        _handler = new DeleteGenreHandler(_genreRepository);
    }
}