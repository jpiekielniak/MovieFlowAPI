using MovieFlow.Modules.Movies.Application.Reviews.Commands.ChangeReview;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Review.Commands.ChangeReview;

internal sealed class ChangeReviewEndpointRequest
{
    [FromRoute(Name = "movieId")] public Guid MovieId { get; init; }
    [FromRoute(Name = "reviewId")] public Guid ReviewId { get; init; }
    [FromBody] public ChangeReviewCommand Command { get; init; } = default;
}