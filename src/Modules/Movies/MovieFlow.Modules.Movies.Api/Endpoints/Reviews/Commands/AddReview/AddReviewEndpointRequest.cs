using MovieFlow.Modules.Movies.Application.Reviews.Commands.AddReview;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Reviews.Commands.AddReview;

internal sealed class AddReviewEndpointRequest
{
    [FromRoute(Name = "movieId")] public Guid MovieId { get; init; }
    [FromBody] public AddReviewCommand Command { get; init; } = default;
}