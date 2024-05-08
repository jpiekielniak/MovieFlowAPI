using MovieFlow.Modules.Movies.Api.Endpoints.Movies;
using MovieFlow.Modules.Movies.Application.Reviews.Queries.GetReviewsGroupedByRating;
using MovieFlow.Modules.Movies.Application.Reviews.Queries.GetReviewsGroupedByRating.DTO;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Reviews.Queries.GetReviewsGroupedByRating;

[Route(MovieEndpoint.Url)]
internal sealed class GetReviewsGroupedByRatingEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<Guid>
    .WithActionResult<List<GroupedReviewsDto>>
{
    [HttpGet("{movieId:guid}/reviews/grouped-by-rating")]
    [SwaggerOperation(
        Summary = "Get reviews grouped by rating",
        Tags = [ReviewEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GroupedReviewsDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    public override async Task<ActionResult<List<GroupedReviewsDto>>> HandleAsync(
        [FromRoute] Guid movieId, 
        CancellationToken cancellationToken = default)
    {
        var query = new GetReviewsGroupedByRatingQuery(movieId);
        return Ok(await mediator.Send(query, cancellationToken));
    }
}