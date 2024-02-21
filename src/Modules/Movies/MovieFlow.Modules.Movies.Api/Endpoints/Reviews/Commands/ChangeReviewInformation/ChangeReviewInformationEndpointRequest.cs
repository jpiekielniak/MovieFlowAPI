using MovieFlow.Modules.Movies.Application.Reviews.Commands.ChangeInformation;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Reviews.Commands.ChangeReviewInformation;

internal sealed class ChangeReviewInformationEndpointRequest
{
    [FromRoute(Name = "movieId")] public Guid MovieId { get; init; }
    [FromRoute(Name = "reviewId")] public Guid ReviewId { get; init; }
    [FromBody] public ChangeReviewInformationCommand Command { get; init; } = default;
}