using MediatR;
using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Directors;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Genres;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Shared.Abstractions;

namespace MovieFlow.Modules.Movies.Application.Movies.Commands.Create;

internal sealed class CreateMovieHandler(
    IMovieRepository movieRepository,
    IGenreRepository genreRepository,
    IDirectorRepository directorRepository)
    : IRequestHandler<CreateMovieCommand, CreateMovieResponse>
{
    public async Task<CreateMovieResponse> Handle(CreateMovieCommand command,
        CancellationToken cancellationToken)
    {
        var movieExists = await movieRepository
            .MovieExistsAsync(command.Title, command.ReleaseYear, cancellationToken);

        if (movieExists)
            throw new MovieAlreadyExistsException(command.Title);

        var director = await directorRepository.GetAsync(command.DirectorId, cancellationToken);

        if (director is null)
            throw new DirectorNotFoundException(command.DirectorId);

        var genreIds = command.Genres.Select(genre => genre.Id).ToList();
        var genreEntities = await genreRepository.GetByIdsAsync(genreIds, cancellationToken);

        var missingGenreIds = genreIds
            .Except(genreEntities.Select(genre => genre.Id))
            .FirstOrDefault();

        if (missingGenreIds != Guid.Empty)
            throw new GenreNotFoundException(missingGenreIds);

        var genres = new List<Genre>();
        genres.AddRange(genreEntities);

        var movie = Movie.Create(
            command.Title,
            command.Description,
            command.ReleaseYear,
            command.Rating,
            director,
            genres
        );

        await movieRepository.AddAsync(movie, cancellationToken);

        return new CreateMovieResponse(movie.Id);
    }
}