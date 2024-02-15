using MovieFlow.Modules.Movies.Application.Movies.Queries.Browse;
using MovieFlow.Modules.Movies.Application.Movies.Queries.Browse.DTO;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Movie.Queries.Browse;

[Route($"{MoviesEndpoint.Url}")]
internal sealed class BrowseMoviesEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<BrowseMoviesQuery>
    .WithActionResult<List<MovieDto>>
{
    [HttpGet]
    [SwaggerOperation(
        Summary = "Browse Movies",
        Tags = [MoviesEndpoint.Tag]
    )]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<MovieDto>))]
    public override async Task<ActionResult<List<MovieDto>>> HandleAsync(
        [FromQuery] BrowseMoviesQuery query,
        CancellationToken cancellationToken = default)
        => Ok(await mediator.Send(query, cancellationToken));
}