using MovieFlow.Modules.Movies.Application.Reviews.Commands.AddLikeToReview;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Reviews.Commands.AddLikeToReview;

internal sealed class AddLikesEndpointRequest
{
    [FromRoute(Name = "movieId")] public Guid MovieId { get; init; }
    [FromRoute(Name = "reviewId")] public Guid ReviewId { get; init; }
    [FromBody] public AddLikeToReviewCommand Command { get; init; } = default;
}