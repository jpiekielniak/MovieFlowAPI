using MovieFlow.Modules.Movies.Api.Endpoints.Movies;
using MovieFlow.Modules.Movies.Application.Reviews.Queries.GetReviewsByMovie;
using MovieFlow.Modules.Movies.Application.Reviews.Queries.GetReviewsByMovie.DTO;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Reviews.Queries.GetReviewsByMovie;

[Route(MovieEndpoint.Url)]
internal sealed class GetReviewsByMovieEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<Guid>
    .WithActionResult<List<ReviewDto>>
{
    [HttpGet("{movieId:guid}/reviews")]
    [SwaggerOperation(
        Summary = "Get reviews by movie id",
        Tags = [ReviewEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ReviewDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    public override async Task<ActionResult<List<ReviewDto>>> HandleAsync(
        [FromRoute] Guid movieId,
        CancellationToken cancellationToken = default)
    {
        var query = new GetReviewsByMovieQuery(movieId);
        return Ok(await mediator.Send(query, cancellationToken));
    }
}