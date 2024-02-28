using MovieFlow.Modules.Movies.Application.Movies.Queries.BrowseMovies;
using MovieFlow.Modules.Movies.Application.Movies.Queries.BrowseMovies.DTO;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Movies.Queries.BrowseMovies;

[Route($"{MovieEndpoint.Url}")]
internal sealed class BrowseMoviesEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<BrowseMoviesQuery>
    .WithActionResult<List<MovieDto>>
{
    [HttpGet]
    [SwaggerOperation(
        Summary = "Browse Movies",
        Tags = [MovieEndpoint.Tag]
    )]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<MovieDto>))]
    public override async Task<ActionResult<List<MovieDto>>> HandleAsync(
        [FromQuery] BrowseMoviesQuery query,
        CancellationToken cancellationToken = default)
        => Ok(await mediator.Send(query, cancellationToken));
}