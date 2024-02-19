using Microsoft.AspNetCore.Authorization;
using MovieFlow.Modules.Movies.Application.Reviews.Commands.Delete;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Review.Commands.Delete;

[Route(MoviesEndpoint.Url)]
internal sealed class DeleteReviewEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<DeleteReviewEndpointRequest>
    .WithoutResult
{
    [Authorize]
    [HttpDelete("{movieId:guid}/reviews/{reviewId:guid}")]
    [SwaggerOperation(
        Summary = "Delete a review",
        Tags = [ReviewsEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    public override async Task HandleAsync(
        DeleteReviewEndpointRequest request,
        CancellationToken cancellationToken = new())
    {
        var command = new DeleteReviewCommand(request.MovieId, request.ReviewId);
        await mediator.Send(command, cancellationToken);
    }
}