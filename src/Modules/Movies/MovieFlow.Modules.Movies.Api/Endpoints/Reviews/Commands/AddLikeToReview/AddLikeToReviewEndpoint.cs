using MovieFlow.Modules.Movies.Api.Endpoints.Movies;
using MovieFlow.Shared.Infrastructure.Api.Attributes;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Reviews.Commands.AddLikeToReview;

[Route(MovieEndpoint.Url)]
internal sealed class AddLikeToReviewEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<AddLikesEndpointRequest>
    .WithoutResult
{
    [Authorize]
    [HttpPost("{movieId:guid}/reviews/{reviewId:guid}/likes")]
    [SwaggerOperation(
        Summary = "Adds likes to review.",
        Tags = [ReviewEndpoint.Tag]
    )]
    [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(void))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    public override async Task HandleAsync(
        [FromRequestSource] AddLikesEndpointRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = request.Command with
        {
            MovieId = request.MovieId,
            ReviewId = request.ReviewId
        };

        await mediator.Send(command, cancellationToken);
    }
}