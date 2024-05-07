using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Actors;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;

namespace MovieFlow.Modules.Movies.Application.Movies.Commands.DeleteActorFromMovie;

internal sealed class DeleteActorFromMovieHandler(IMovieRepository movieRepository,
    IActorRepository actorRepository) : IRequestHandler<DeleteActorFromMovieCommand>
{
    public async Task Handle(DeleteActorFromMovieCommand command, CancellationToken cancellationToken)
    {
        var movie = await movieRepository
            .GetAsync(command.MovieId, cancellationToken)
            .NotNull(() => throw new MovieNotFoundException(command.MovieId));

        var actor = await actorRepository
            .GetAsync(command.ActorId, cancellationToken)
            .NotNull(() => throw new ActorNotFoundException(command.ActorId));
        
        movie.RemoveActor(actor);
        await movieRepository.UpdateAsync(movie, cancellationToken);
    }
}