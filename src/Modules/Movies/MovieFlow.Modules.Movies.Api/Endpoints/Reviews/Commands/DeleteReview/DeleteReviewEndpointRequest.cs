namespace MovieFlow.Modules.Movies.Api.Endpoints.Reviews.Commands.DeleteReview;

internal sealed class DeleteReviewEndpointRequest
{
    [FromRoute(Name = "movieId")] public Guid MovieId { get; init; }
    [FromRoute(Name = "reviewId")] public Guid ReviewId { get; init; }
}