using MediatR;
using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Genres;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;

namespace MovieFlow.Modules.Movies.Application.Movies.Commands.Create;

internal sealed class CreateMovieHandler(
    IMovieRepository movieRepository,
    IGenreRepository genreRepository)
    : IRequestHandler<CreateMovieCommand, CreateMovieResponse>
{
    public async Task<CreateMovieResponse> Handle(CreateMovieCommand command,
        CancellationToken cancellationToken)
    {
        var movieExists = await movieRepository
            .MovieExistsAsync(command.Title, command.ReleaseYear, cancellationToken);

        if (movieExists)
            throw new MovieAlreadyExistsException(command.Title);

        var genres = new List<Genre>();
        foreach (var genre in command.Genres)
        {
            var genreEntity = await genreRepository.GetByIdAsync(genre.Id, cancellationToken);

            if (genreEntity is null)
                throw new GenreNotFoundException(genre.Id);

            genres.Add(genreEntity);
        }

        var movie = Movie.Create(
            command.Title,
            command.Description,
            command.ReleaseYear,
            command.Rating,
            genres
        );

        await movieRepository.AddAsync(movie, cancellationToken);

        return new CreateMovieResponse(movie.Id);
    }
}