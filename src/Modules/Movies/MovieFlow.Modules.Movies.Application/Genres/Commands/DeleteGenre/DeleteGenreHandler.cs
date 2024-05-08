using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Genres;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;

namespace MovieFlow.Modules.Movies.Application.Genres.Commands.DeleteGenre;

internal sealed class DeleteGenreHandler(IGenreRepository genreRepository)
    : IRequestHandler<DeleteGenreCommand>
{
    public async Task Handle(DeleteGenreCommand command, CancellationToken cancellationToken)
    {
        var genre = await genreRepository
            .GetAsync(command.GenreId, cancellationToken)
            .NotNull(() => new GenreNotFoundException(command.GenreId));

        await genreRepository.DeleteAsync(genre, cancellationToken);
    }
}