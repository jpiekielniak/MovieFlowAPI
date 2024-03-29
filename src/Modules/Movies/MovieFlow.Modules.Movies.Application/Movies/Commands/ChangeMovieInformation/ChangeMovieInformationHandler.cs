using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;

namespace MovieFlow.Modules.Movies.Application.Movies.Commands.ChangeMovieInformation;

internal sealed class ChangeMovieInformationHandler(IMovieRepository movieRepository)
    : IRequestHandler<ChangeMovieInformationCommand>
{
    public async Task Handle(ChangeMovieInformationCommand command,
        CancellationToken cancellationToken)
    {
        var movie = await movieRepository.GetAsync(command.MovieId, cancellationToken)
            .NotNull(() => new MovieNotFoundException(command.MovieId));

        movie.ChangeInformation(
            command.Title,
            command.Description,
            command.ReleaseYear);

        await movieRepository.CommitAsync(cancellationToken);
    }
}