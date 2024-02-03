using MovieFlow.Modules.Movies.Application.Movies.Commands.ChangeMovieInformation;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Movie.Commands.ChangeMovieInformation;

internal sealed class ChangeMovieInformationRequest
{
    [FromRoute(Name = "movieId")] public Guid MovieId { get; init; }
    [FromBody] public ChangeMovieInformationCommand Command { get; init; } = default;
}