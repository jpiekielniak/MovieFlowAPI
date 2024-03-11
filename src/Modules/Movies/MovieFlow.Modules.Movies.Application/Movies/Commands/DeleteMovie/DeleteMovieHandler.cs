using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;

namespace MovieFlow.Modules.Movies.Application.Movies.Commands.DeleteMovie;

internal sealed class DeleteMovieHandler(IMovieRepository movieRepository) : IRequestHandler<DeleteMovieCommand>
{
    public async Task Handle(DeleteMovieCommand command, CancellationToken cancellationToken)
    {
        var movie = await movieRepository
            .GetAsync(command.MovieId, cancellationToken)
            .NotNull(() => new MovieNotFoundException(command.MovieId));

        await movieRepository.DeleteAsync(movie, cancellationToken);
    }
}