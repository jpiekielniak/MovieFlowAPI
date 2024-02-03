using MediatR;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Shared.Abstractions.Time;

namespace MovieFlow.Modules.Movies.Application.Movies.Commands.ChangeMovieInformation;

internal sealed class ChangeMovieInformationHandler(
    IMovieRepository movieRepository,
    IClock clock
) : IRequestHandler<ChangeMovieInformationCommand>
{
    public async Task Handle(
        ChangeMovieInformationCommand command,
        CancellationToken cancellationToken)
    {
        var movie = await movieRepository.GetAsync(command.MovieId, cancellationToken);

        if (movie is null)
            throw new MovieDoesNotExistException(command.MovieId);

        movie.ChangeInformation(
            command.Title,
            command.Description,
            command.ReleaseYear,
            command.Rating,
            clock.CurrentDateTimeOffset()
        );
        
        await movieRepository.UpdateAsync(movie, cancellationToken);
        await movieRepository.CommitAsync(cancellationToken);
    }
}