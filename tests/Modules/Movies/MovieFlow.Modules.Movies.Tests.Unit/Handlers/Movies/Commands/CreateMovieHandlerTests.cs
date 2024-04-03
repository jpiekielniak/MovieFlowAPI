using MovieFlow.Modules.Movies.Application.Movies.Commands.CreateMovie;
using MovieFlow.Modules.Movies.Application.Movies.Commands.CreateMovie.DTO;
using MovieFlow.Modules.Movies.AzureStorage.Services;
using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Directors;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Modules.Newsletters.Shared.Events.CreatedMovie;

namespace MovieFlow.Modules.Movies.Tests.Unit.Handlers.Movies.Commands;

public class CreateMovieHandlerTests
{
    private async Task<CreateMovieResponse> Act(CreateMovieCommand command) =>
        await _handler.Handle(command, CancellationToken.None);

    [Fact]
    public async Task given_already_existing_movie_should_fail()
    {
        //Arrange
        var command = CreateMovieCommand([]);
        _movieRepository.MovieExistsAsync(command.Title, command.ReleaseYear, Arg.Any<CancellationToken>())
            .Returns(true);

        //Act
        var exception = await Record.ExceptionAsync(() => Act(command));

        // Assert
        exception.ShouldBeOfType<MovieAlreadyExistsException>();
        await _mediator.DidNotReceiveWithAnyArgs().Publish(Arg.Any<CreatedMovieEvent>(), Arg.Any<CancellationToken>());
        await _movieRepository.DidNotReceiveWithAnyArgs().AddAsync(Arg.Any<Movie>(), Arg.Any<CancellationToken>());
        await _movieRepository.Received(1)
            .MovieExistsAsync(command.Title, command.ReleaseYear, Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task given_not_existing_director_should_fail()
    {
        //Arrange
        var command = CreateMovieCommand([]);
        _directorRepository.GetAsync(command.DirectorId, Arg.Any<CancellationToken>())
            .Returns((Director)null);

        //Act
        var exception = await Record.ExceptionAsync(() => Act(command));

        //Assert
        exception.ShouldBeOfType<DirectorNotFoundException>();
        await _movieRepository.Received(1)
            .MovieExistsAsync(command.Title, command.ReleaseYear, Arg.Any<CancellationToken>());
        await _directorRepository.Received(1).GetAsync(command.DirectorId, Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task given_valid_data_should_create_movie()
    {
        // Arrange
        var genres = new List<Genre> { Genre.Create("Action"), Genre.Create("Adventure") };
        var ids = genres.Select(x => new GenreDto(x.Id)).ToList();
        var command = CreateMovieCommand(ids);
        command = command with { Photo = _photo };
        var director = Director.Create("John", "Doe", new DateTime(1970, 4, 15), "USA");
        _movieRepository.MovieExistsAsync(command.Title, command.ReleaseYear, Arg.Any<CancellationToken>())
            .Returns(false);
        _movieRepository.AddAsync(Arg.Any<Movie>(), Arg.Any<CancellationToken>()).Returns(Task.CompletedTask);
        _directorRepository.GetAsync(command.DirectorId, CancellationToken.None).Returns(director);
        _genreRepository.GetByIdsAsync(Arg.Any<List<Guid>>(), CancellationToken.None).Returns(genres);
        _azureStorageService.UploadImageAsync(Arg.Any<IFormFile>()).Returns(Task.CompletedTask);
        _azureStorageService.GetImageUrlAsync(Arg.Any<string>()).Returns("www.example-url.com");

        // Act
        var response = await Act(command);

        // Assert
        await _movieRepository.Received(1).AddAsync(Arg.Any<Movie>(), Arg.Any<CancellationToken>());
        await _mediator.Received(1).Publish(Arg.Any<CreatedMovieEvent>(), Arg.Any<CancellationToken>());
        await _azureStorageService.Received(1).UploadImageAsync(Arg.Any<IFormFile>());
        await _azureStorageService.Received(1).GetImageUrlAsync(Arg.Any<string>());
        response.ShouldBeOfType<CreateMovieResponse>();
        response.MovieId.ShouldNotBe(Guid.Empty);
    }

    private readonly IRequestHandler<CreateMovieCommand, CreateMovieResponse> _handler;
    private readonly IMovieRepository _movieRepository;
    private readonly IDirectorRepository _directorRepository;
    private readonly IGenreRepository _genreRepository;
    private readonly IAzureStorageService _azureStorageService;
    private readonly IMediator _mediator;
    private readonly IFormFile _photo;

    public CreateMovieHandlerTests()
    {
        _azureStorageService = Substitute.For<IAzureStorageService>();
        _genreRepository = Substitute.For<IGenreRepository>();
        _movieRepository = Substitute.For<IMovieRepository>();
        _directorRepository = Substitute.For<IDirectorRepository>();
        _mediator = Substitute.For<IMediator>();
        _photo = Substitute.For<IFormFile>();

        _handler = new CreateMovieHandler(
            _movieRepository,
            _genreRepository,
            _directorRepository,
            _azureStorageService,
            _mediator
        );
    }
    
    private static CreateMovieCommand CreateMovieCommand(List<GenreDto> genres) =>
        new("Title", "Description", 2021, Guid.NewGuid(), genres);
}