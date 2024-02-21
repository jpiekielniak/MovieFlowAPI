using MovieFlow.Modules.Movies.Api.Endpoints.Movies;
using MovieFlow.Modules.Movies.Application.Reviews.Commands.Delete;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Reviews.Commands.DeleteReview;

[Route(MovieEndpoint.Url)]
internal sealed class DeleteReviewEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<DeleteReviewEndpointRequest>
    .WithoutResult
{
    [Authorize]
    [HttpDelete("{movieId:guid}/reviews/{reviewId:guid}")]
    [SwaggerOperation(
        Summary = "Delete a review",
        Tags = [ReviewEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    public override async Task HandleAsync(DeleteReviewEndpointRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteReviewCommand(request.MovieId, request.ReviewId);
        await mediator.Send(command, cancellationToken);
    }
}