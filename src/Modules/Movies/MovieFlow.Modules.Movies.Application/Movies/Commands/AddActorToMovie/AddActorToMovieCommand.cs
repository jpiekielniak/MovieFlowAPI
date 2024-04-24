namespace MovieFlow.Modules.Movies.Application.Movies.Commands.AddActorToMovie;

internal record AddActorToMovieCommand(Guid ActorId) : IRequest
{
    internal Guid MovieId;
}