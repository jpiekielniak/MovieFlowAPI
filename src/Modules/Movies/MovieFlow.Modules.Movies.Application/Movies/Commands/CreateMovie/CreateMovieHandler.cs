using MovieFlow.Modules.Movies.Application.Movies.Commands.CreateMovie.DTO;
using MovieFlow.Modules.Movies.AzureStorage.Services;
using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Directors;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Genres;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Modules.Newsletters.Shared.Events.CreatedMovie;

namespace MovieFlow.Modules.Movies.Application.Movies.Commands.CreateMovie;

internal sealed class CreateMovieHandler(
    IMovieRepository movieRepository,
    IGenreRepository genreRepository,
    IDirectorRepository directorRepository,
    IAzureStorageService azureStorageService,
    IMediator mediator)
    : IRequestHandler<CreateMovieCommand, CreateMovieResponse>
{
    public async Task<CreateMovieResponse> Handle(CreateMovieCommand command,
        CancellationToken cancellationToken)
    {
        var movieExists = await movieRepository
            .MovieExistsAsync(command.Title, command.ReleaseYear, cancellationToken);

        if (movieExists)
            throw new MovieAlreadyExistsException(command.Title);

        var director = await directorRepository
            .GetAsync(command.DirectorId, cancellationToken)
            .NotNull(() => new DirectorNotFoundException(command.DirectorId));

        var genres = await GetGenres(command.Genres, cancellationToken);

        await azureStorageService.UploadImageAsync(command.Photo);
        var photoUrl = await azureStorageService.GetImageUrlAsync(command.Photo.FileName);

        var movie = Movie.Create(
            command.Title,
            command.Description,
            command.ReleaseYear,
            director,
            genres
        );

        var photo = Photo.Create(
            command.Photo.FileName,
            photoUrl,
            command.Title,
            command.Photo.ContentType
        );

        movie.AddPhoto(photo);
        await movieRepository.AddAsync(movie, cancellationToken);

        var @event = new CreatedMovieEvent(movie.Title, movie.Description, photoUrl);
        await mediator.Publish(@event, cancellationToken);

        return new CreateMovieResponse(movie.Id);
    }

    private async Task<List<Genre>> GetGenres(IReadOnlyCollection<GenreDto> genreIds,
        CancellationToken cancellationToken)
    {
        var ids = genreIds.Select(g => g.Id).ToList();
        var genres = await genreRepository.GetByIdsAsync(ids, cancellationToken);

        if (genres.Count == genreIds.Count)
            return genres;

        var missingGenreIds = ids
            .Except(genres.Select(g => g.Id))
            .FirstOrDefault();

        throw new GenreNotFoundException(missingGenreIds);
    }
}