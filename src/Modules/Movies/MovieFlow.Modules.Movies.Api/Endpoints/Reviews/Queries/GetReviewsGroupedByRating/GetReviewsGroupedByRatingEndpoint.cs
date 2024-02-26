using MovieFlow.Modules.Movies.Api.Endpoints.Movies;
using MovieFlow.Modules.Movies.Application.Reviews.Queries.GetReviewsGroupedByRating;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Reviews.Queries.GetReviewsGroupedByRating;

[Route(MovieEndpoint.Url)]
internal sealed class GetReviewsGroupedByRatingEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<Guid>
    .WithActionResult<GetReviewsGroupedByRatingResponse>
{
    [HttpGet("{movieId:guid}/reviews/grouped-by-rating")]
    [SwaggerOperation(
        Summary = "Get reviews grouped by rating",
        Tags = [ReviewEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetReviewsGroupedByRatingResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    public override async Task<ActionResult<GetReviewsGroupedByRatingResponse>> HandleAsync(
        [FromRoute] Guid movieId, CancellationToken cancellationToken = default)
    {
        var query = new GetReviewsGroupedByRatingQuery(movieId);
        var result = await mediator.Send(query, cancellationToken);

        return Ok(result);
    }
}