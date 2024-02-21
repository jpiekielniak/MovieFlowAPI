using MovieFlow.Modules.Movies.Api.Endpoints.Movies;
using MovieFlow.Modules.Movies.Application.Reviews.Commands.Add;
using MovieFlow.Shared.Infrastructure.Api.Attributes;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Reviews.Commands.AddReview;

[Route(MovieEndpoint.Url)]
internal sealed class AddReviewEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<AddReviewEndpointRequest>
    .WithActionResult<AddReviewResponse>
{
    [Authorize]
    [HttpPost("{movieId:Guid}/reviews")]
    [SwaggerOperation(
        Summary = "Add review to movie",
        Tags = [ReviewEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AddReviewResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    public override async Task<ActionResult<AddReviewResponse>> HandleAsync(
        [FromRequestSource] AddReviewEndpointRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = request.Command with { MovieId = request.MovieId };
        var response = await mediator.Send(command, cancellationToken);

        return Ok(response.reviewId);
    }
        
}