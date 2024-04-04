using MovieFlow.Modules.Movies.Application.Movies.Commands.AddPhotoToMovie;
using MovieFlow.Modules.Movies.AzureStorage.Services;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using NSubstitute.ReturnsExtensions;
using static MovieFlow.Modules.Movies.Tests.Unit.Extensions.Extensions;

namespace MovieFlow.Modules.Movies.Tests.Unit.Handlers.Movies.Commands;

public class AddPhotoToMovieHandlerTests
{
    private async Task Act(AddPhotoToMovieCommand command)
        => await _handler.Handle(command, CancellationToken.None);

    [Fact]
    public async Task given_valid_data_should_add_photo_to_movie()
    {
        // Arrange
        var movie = GetValidMovie();
        var command = AddPhotoToMovieCommand(movie.Id);
        _movieRepository.GetAsync(command.MovieId, Arg.Any<CancellationToken>())
            .Returns(movie);

        // Act
        await Act(command);

        // Assert
        movie.Photos.ShouldNotBeEmpty();
        await _movieRepository.Received(1).GetAsync(command.MovieId, Arg.Any<CancellationToken>());
        await _azureStorageService.Received(1).UploadImageAsync(command.Photo);
        await _azureStorageService.Received(1).GetImageUrlAsync(command.Photo.FileName);
    }

    [Fact]
    public async Task given_invalid_movie_id_should_throw_movie_not_found_exception()
    {
        // Arrange
        var command = AddPhotoToMovieCommand(Guid.NewGuid());
        _movieRepository.GetAsync(command.MovieId, Arg.Any<CancellationToken>())
            .ReturnsNull();

        // Act
        var exception = await Record.ExceptionAsync(() => Act(command));

        // Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<MovieNotFoundException>();
        exception.Message.ShouldBe($"Movie with id {command.MovieId} not found.");
    }


    private readonly IRequestHandler<AddPhotoToMovieCommand> _handler;
    private readonly IAzureStorageService _azureStorageService;
    private readonly IMovieRepository _movieRepository;

    public AddPhotoToMovieHandlerTests()
    {
        _azureStorageService = Substitute.For<IAzureStorageService>();
        _movieRepository = Substitute.For<IMovieRepository>();

        _handler = new AddPhotoToMovieHandler(
            _azureStorageService,
            _movieRepository
        );
    }

    private static AddPhotoToMovieCommand AddPhotoToMovieCommand(Guid movieId)
    {
        var command = new AddPhotoToMovieCommand(CreateFormFile());
        return command with { MovieId = movieId };
    }
}