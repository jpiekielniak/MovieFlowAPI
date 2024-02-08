using MediatR;
using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Directors;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;

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

        var genreIds = command.Genres.Select(x => x.Id).ToList();
        var genres = await genreRepository.GetByIdsAsync(genreIds, cancellationToken);
        
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