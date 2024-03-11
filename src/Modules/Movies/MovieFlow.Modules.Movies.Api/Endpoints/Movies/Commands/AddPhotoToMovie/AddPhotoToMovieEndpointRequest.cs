using MovieFlow.Modules.Movies.Application.Movies.Commands.AddPhotoToMovie;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Movies.Commands.AddPhotoToMovie;

internal class AddPhotoToMovieEndpointRequest
{
    [FromRoute(Name = "movieId")] public Guid MovieId { get; init; }

    public AddPhotoToMovieCommand Command { get; init; } = default!;
}