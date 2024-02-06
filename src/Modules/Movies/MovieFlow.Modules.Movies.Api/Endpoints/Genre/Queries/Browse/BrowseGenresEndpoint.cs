using MovieFlow.Modules.Movies.Application.Genres.DTO;
using MovieFlow.Modules.Movies.Application.Genres.Queries.Browse;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Genre.Queries.Browse;

[Route($"{GenresEndpoint.Url}")]
internal sealed class BrowseGenresEndpoint(
    IMediator mediator) : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<List<BrowseGenresDto>>
{
    [HttpGet]
    [SwaggerOperation(
        Summary = "Browse Genres",
        Tags = [GenresEndpoint.Tag]
    )]
    [SwaggerResponse(StatusCodes.Status200OK)]
    public override async Task<ActionResult<List<BrowseGenresDto>>> HandleAsync(
        CancellationToken cancellationToken = new())
        => Ok(await mediator.Send(new BrowseGenresQuery(), cancellationToken));
}