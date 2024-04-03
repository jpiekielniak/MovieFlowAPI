using MovieFlow.Modules.Movies.Application.Movies.Commands.DeletePhotoFromMovie;
using MovieFlow.Modules.Movies.AzureStorage.Events.Events.PhotoDeleted;
using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Photos;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using NSubstitute.ReturnsExtensions;
using static MovieFlow.Modules.Movies.Tests.Unit.Extensions.Extensions;

namespace MovieFlow.Modules.Movies.Tests.Unit.Handlers.Movies.Commands;

public class DeletePhotoFromMovieHandlerTests
{
    private async Task Act(DeletePhotoFromMovieCommand command)
        => await _handler.Handle(command, CancellationToken.None);

    [Fact]
    public async Task given_valid_command_should_delete_photo_from_movie()
    {
        // Arrange
        var movie = GetValidMovie();
        var command = DeletePhotoFromMovieCommand(movie.Id);
        movie.AddPhoto(CreatePhoto());
        movie.AddPhoto(CreatePhoto());
        _photoRepository.GetAsync(command.PhotoId, Arg.Any<CancellationToken>())
            .Returns(movie.Photos.First());
        _movieRepository.GetAsync(command.MovieId, Arg.Any<CancellationToken>())
            .Returns(movie);

        // Act
        await Act(command);

        // Assert
        movie.Photos.Count.ShouldBe(1);
        await _photoRepository.Received(1).DeleteAsync(Arg.Any<Photo>(), Arg.Any<CancellationToken>());
        await _mediator.Received(1).Publish(Arg.Any<PhotoDeletedEvent>(), Arg.Any<CancellationToken>());
    }
    
    [Fact]
    public async Task given_valid_command_should_throw_movie_must_have_at_least_one_photo_exception()
    {
        // Arrange
        var movie = GetValidMovie();
        var command = DeletePhotoFromMovieCommand(movie.Id);
        movie.AddPhoto(CreatePhoto());
        _photoRepository.GetAsync(command.PhotoId, Arg.Any<CancellationToken>())
            .Returns(movie.Photos.First());
        _movieRepository.GetAsync(command.MovieId, Arg.Any<CancellationToken>())
            .Returns(movie);

        // Act
        var exception = await Record.ExceptionAsync(() => Act(command));

        // Assert
        exception.ShouldBeOfType<MovieMustHaveAtLeastOnePhotoException>();
    }

    [Fact]
    public async Task given_invalid_movie_id_should_throw_movie_not_found_exception()
    {
        //Arrange
        var command = DeletePhotoFromMovieCommand(Guid.NewGuid());
        _movieRepository.GetAsync(command.MovieId, Arg.Any<CancellationToken>())
            .ReturnsNull();
        
        //Act
        var exception = await Record.ExceptionAsync(() => Act(command));
        
        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<MovieNotFoundException>();
        await _movieRepository.Received(1).GetAsync(command.MovieId, Arg.Any<CancellationToken>());
    }
    
    [Fact]
    public async Task given_invalid_photo_id_should_throw_photo_not_found_exception()
    {
        //Arrange
        var movie = GetValidMovie();
        var command = DeletePhotoFromMovieCommand(movie.Id);
        _photoRepository.GetAsync(command.PhotoId, Arg.Any<CancellationToken>())
            .ReturnsNull();
        _movieRepository.GetAsync(command.MovieId, Arg.Any<CancellationToken>())
            .Returns(movie);
        
        //Act
        var exception = await Record.ExceptionAsync(() => Act(command));
        
        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<PhotoNotFoundException>();
        await _movieRepository.Received(1).GetAsync(command.MovieId, Arg.Any<CancellationToken>());
        await _photoRepository.Received(1).GetAsync(command.PhotoId, Arg.Any<CancellationToken>());
    }

    private readonly IRequestHandler<DeletePhotoFromMovieCommand> _handler;
    private readonly IMovieRepository _movieRepository;
    private readonly IPhotoRepository _photoRepository;
    private readonly IMediator _mediator;

    public DeletePhotoFromMovieHandlerTests()
    {
        _movieRepository = Substitute.For<IMovieRepository>();
        _photoRepository = Substitute.For<IPhotoRepository>();
        _mediator = Substitute.For<IMediator>();

        _handler = new DeletePhotoFromMovieHandler(
            _movieRepository,
            _photoRepository,
            _mediator
        );
    }

    private static DeletePhotoFromMovieCommand DeletePhotoFromMovieCommand(Guid movieId)
    {
        var command = new DeletePhotoFromMovieCommand(Guid.NewGuid());

        return command with { MovieId = movieId };
    }
}