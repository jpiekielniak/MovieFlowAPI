using MovieFlow.Modules.Movies.Application.Movies.Commands.AddActorToMovie;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Movies.Commands.AddActorToMovie;

internal class AddActorToMovieEndpointRequest
{
    [FromRoute(Name = "movieId")] public Guid MovieId { get; init; }

    [FromBody] public AddActorToMovieCommand Command { get; init; } = default!;
}