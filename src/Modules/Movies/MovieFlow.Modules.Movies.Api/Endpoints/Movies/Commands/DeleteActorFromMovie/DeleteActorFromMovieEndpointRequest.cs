using MovieFlow.Modules.Movies.Application.Movies.Commands.DeleteActorFromMovie;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Movies.Commands.DeleteActorFromMovie;

internal class DeleteActorFromMovieEndpointRequest
{
    [FromRoute(Name = "movieId")] public Guid MovieId { get; init; }
    [FromBody] public DeleteActorFromMovieCommand Command { get; init; } = default!;
}