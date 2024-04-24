using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Actors;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;

namespace MovieFlow.Modules.Movies.Application.Movies.Commands.AddActorToMovie;

internal sealed class AddActorToMovieHandler(
    IMovieRepository movieRepository,
    IActorRepository actorRepository) : IRequestHandler<AddActorToMovieCommand>
{
    public async Task Handle(AddActorToMovieCommand command, CancellationToken cancellationToken)
    {
        var movie = await movieRepository
            .GetAsync(command.MovieId, cancellationToken)
            .NotNull(() => new MovieNotFoundException(command.MovieId));
        
        var actor = await actorRepository
            .GetAsync(command.ActorId, cancellationToken)
            .NotNull(() => new ActorNotFoundException(command.ActorId));
        
        movie.AddActor(actor);
        await movieRepository.UpdateAsync(movie, cancellationToken);
    }
}