using MovieFlow.Modules.Movies.AzureStorage.Events.Events.PhotoDeleted;
using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Photos;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;

namespace MovieFlow.Modules.Movies.Application.Movies.Commands.DeletePhotoFromMovie;

internal sealed class DeletePhotoFromMovieHandler(
    IMovieRepository movieRepository,
    IPhotoRepository photoRepository,
    IMediator mediator) : IRequestHandler<DeletePhotoFromMovieCommand>
{
    public async Task Handle(DeletePhotoFromMovieCommand command, CancellationToken cancellationToken)
    {
        var movie = await movieRepository
            .GetAsync(command.MovieId, cancellationToken)
            .NotNull(() => new MovieNotFoundException(command.MovieId));

        if (IsLastPhoto(movie))
            throw new MovieMustHaveAtLeastOnePhotoException();

        var photo = await photoRepository
            .GetAsync(command.PhotoId, cancellationToken)
            .NotNull(() => new PhotoNotFoundException(command.PhotoId));

        await photoRepository.DeleteAsync(photo, cancellationToken);

        var @event = new PhotoDeletedEvent(photo.FileName);
        await mediator.Publish(@event, cancellationToken);
    }

    private static bool IsLastPhoto(Movie movie)
        => movie.MoviePhotos.Count() == 1;
}