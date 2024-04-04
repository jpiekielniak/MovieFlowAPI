using MovieFlow.Modules.Movies.Application.Genres.Commands.CreateGenre;
using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Genres;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using static MovieFlow.Modules.Movies.Tests.Unit.Extensions.Extensions;

namespace MovieFlow.Modules.Movies.Tests.Unit.Handlers.Genres.Commands;

public class CreateGenreHandlerTests
{
    private async Task<CreateGenreResponse> Act(CreateGenreCommand command)
        => await _handler.Handle(command, CancellationToken.None);

    [Theory]
    [MemberData(nameof(GetValidGenreName), MemberType = typeof(Extensions.Extensions))]
    public async Task given_valid_name_should_succeed(string value)
    {
        //Arrange
        var command = new CreateGenreCommand(value);
        _genreRepository.ExistsByNameAsync(command.Name, Arg.Any<CancellationToken>())
            .Returns(false);
        _genreRepository.AddAsync(Arg.Any<Genre>(), Arg.Any<CancellationToken>())
            .Returns(Task.CompletedTask);

        //Act
        var response = await Act(command);

        //Assert
        response.ShouldNotBeNull();
        response.GenreId.ShouldBeAssignableTo<Guid>();
        response.GenreId.ShouldNotBeSameAs(Guid.Empty);
        await _genreRepository.Received(1).ExistsByNameAsync(command.Name, Arg.Any<CancellationToken>());
        await _genreRepository.Received(1).AddAsync(Arg.Any<Genre>(), Arg.Any<CancellationToken>());
    }
    
    [Fact]
    public async Task given_existing_genre_name_should_throw_genre_already_exists_exception()
    {
        //Arrange
        var command = new CreateGenreCommand("Action");
        _genreRepository.ExistsByNameAsync(command.Name, Arg.Any<CancellationToken>())
            .Returns(true);

        //Act
        var exception = await Record.ExceptionAsync(() => Act(command));

        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<GenreAlreadyExistsException>();
        await _genreRepository.Received(1).ExistsByNameAsync(command.Name, Arg.Any<CancellationToken>());
        await _genreRepository.DidNotReceive().AddAsync(Arg.Any<Genre>(), Arg.Any<CancellationToken>());
    }

    private readonly IRequestHandler<CreateGenreCommand, CreateGenreResponse> _handler;
    private readonly IGenreRepository _genreRepository;

    public CreateGenreHandlerTests()
    {
        _genreRepository = Substitute.For<IGenreRepository>();
        _handler = new CreateGenreHandler(_genreRepository);
    }

    
}