using MovieFlow.Modules.Movies.Application.Reviews.Queries.GetByMovie;
using MovieFlow.Modules.Movies.Application.Reviews.Queries.GetByMovie.DTO;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Review.Queries.GetByMovie;

[Route(MoviesEndpoint.Url)]
internal sealed class GetByMovieEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<GetByMovieQuery>
    .WithActionResult<List<ReviewDto>>
{
    [HttpGet("{movieId:guid}/reviews")]
    [SwaggerOperation(
        Summary = "Get reviews by movie id",
        Tags = [ReviewsEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ReviewDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    public override async Task<ActionResult<List<ReviewDto>>> HandleAsync(
        [FromRoute] GetByMovieQuery query,
        CancellationToken cancellationToken = new())
        => Ok(await mediator.Send(query, cancellationToken));
}