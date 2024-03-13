using MovieFlow.Modules.Movies.Application.Movies.Commands.DeletePhotoFromMovie;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Movies.Commands.DeletePhotoFromMovie;

internal sealed class DeletePhotoFromMovieEndpointRequest
{
    [FromRoute(Name = "movieId")] public Guid MovieId { get; init; }
    [FromBody] public DeletePhotoFromMovieCommand Command { get; init; } = default!;
}