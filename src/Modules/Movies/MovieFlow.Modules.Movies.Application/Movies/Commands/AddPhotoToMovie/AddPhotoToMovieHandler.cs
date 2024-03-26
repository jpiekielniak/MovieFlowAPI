using MovieFlow.Modules.Movies.AzureStorage.Services;
using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;

namespace MovieFlow.Modules.Movies.Application.Movies.Commands.AddPhotoToMovie;

internal sealed class AddPhotoToMovieHandler(
    IAzureStorageService azureStorageService,
    IMovieRepository movieRepository,
    IPhotoRepository photoRepository) : IRequestHandler<AddPhotoToMovieCommand>
{
    public async Task Handle(AddPhotoToMovieCommand command, CancellationToken cancellationToken)
    {
        var movie = await movieRepository
            .GetAsync(command.MovieId, cancellationToken)
            .NotNull(() => new MovieNotFoundException(command.MovieId));

        await azureStorageService.UploadImageAsync(command.Photo);

        var photoUrl = await azureStorageService.GetImageUrlAsync(command.Photo.FileName);

        var photo = Photo.Create(
            command.Photo.FileName,
            photoUrl,
            movie.Title,
            command.Photo.ContentType
        );
        
        movie.AddPhoto(photo);
        await photoRepository.AddAsync(photo, cancellationToken);
    }
}