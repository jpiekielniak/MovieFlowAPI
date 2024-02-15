using Microsoft.AspNetCore.Authorization;
using MovieFlow.Modules.Movies.Application.Reviews.Commands.AddReview;
using MovieFlow.Shared.Infrastructure.Api.Attributes;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Review.Commands.AddReview;

[Route(MoviesEndpoint.Url)]
internal sealed class AddReviewEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<AddReviewEndpointRequest>
    .WithActionResult<AddReviewResponse>
{
    [Authorize]
    [HttpPost("{movieId:Guid}/reviews")]
    [SwaggerOperation(
        Summary = "Add review to movie",
        Tags = [MoviesEndpoint.Tag]
    )]
    [ProducesResponseType( StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorsResponse),StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    public override async Task<ActionResult<AddReviewResponse>> HandleAsync(
        [FromRequestSource] AddReviewEndpointRequest request,
        CancellationToken cancellationToken = new())
        => Ok(await mediator.Send(request.Command with { MovieId = request.MovieId }, cancellationToken));
}