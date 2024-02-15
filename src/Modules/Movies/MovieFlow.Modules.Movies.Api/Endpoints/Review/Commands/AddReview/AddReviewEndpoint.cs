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
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AddReviewResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    public override async Task<ActionResult<AddReviewResponse>> HandleAsync(
        [FromRequestSource] AddReviewEndpointRequest request,
        CancellationToken cancellationToken = new())
        => Ok(await mediator.Send(request.Command with { MovieId = request.MovieId }, cancellationToken));
}