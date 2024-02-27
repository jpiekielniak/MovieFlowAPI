using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Genres;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;

namespace MovieFlow.Modules.Movies.Application.Genres.Commands.CreateGenre;

internal sealed class CreateGenreHandler(IGenreRepository genreRepository)
    : IRequestHandler<CreateGenreCommand, CreateGenreResponse>
{
    public async Task<CreateGenreResponse> Handle(CreateGenreCommand command,
        CancellationToken cancellationToken)
    {
        var genreExists = await genreRepository
            .ExistsByNameAsync(command.Name, cancellationToken);

        if (genreExists)
            throw new GenreAlreadyExistsException(command.Name);

        var genre = Genre.Create(command.Name);

        await genreRepository.AddAsync(genre, cancellationToken);

        return new CreateGenreResponse(genre.Id);
    }
}