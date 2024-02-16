using MovieFlow.Modules.Movies.Application.Reviews.Commands.AddLikes;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Review.Commands.AddLikes;

internal sealed class AddLikesEndpointRequest
{
    [FromRoute(Name = "movieId")] public Guid MovieId { get; init; }
    [FromRoute(Name = "reviewId")] public Guid ReviewId { get; init; }
    [FromBody] public AddLikesCommand Command { get; init; } = default;
}