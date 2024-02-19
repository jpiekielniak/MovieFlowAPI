using MovieFlow.Modules.Movies.Application.Reviews.Commands.Add;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Review.Commands.Add;

internal sealed class AddReviewEndpointRequest
{
    [FromRoute(Name = "movieId")] public Guid MovieId { get; init; }
    [FromBody] public AddReviewCommand Command { get; init; } = default;
}