namespace MovieFlow.Modules.Movies.Application.Movies.Commands.DeleteActorFromMovie;

internal record DeleteActorFromMovieCommand(Guid ActorId) : IRequest
{
    internal Guid MovieId;
}