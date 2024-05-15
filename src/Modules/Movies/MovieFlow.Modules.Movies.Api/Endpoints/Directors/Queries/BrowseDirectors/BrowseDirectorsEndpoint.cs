using MovieFlow.Modules.Movies.Application.Directors.Queries.BrowseDirectors;
using MovieFlow.Modules.Movies.Application.Movies.Queries.BrowseMovies.DTO;
using MovieFlow.Modules.Movies.Application.Shared.DTO;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Directors.Queries.BrowseDirectors;

[Route(DirectorEndpoint.Url)]
internal sealed class BrowseDirectorsEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<BrowseDirectorsQuery>
    .WithActionResult<List<BrowseDirectorDto>>
{
    [HttpGet]
    [SwaggerOperation(
        Summary = "Browse directors",
        Tags = [DirectorEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DirectorDto>))]
    public override async Task<ActionResult<List<BrowseDirectorDto>>> HandleAsync(
        [FromQuery] BrowseDirectorsQuery query,
        CancellationToken cancellationToken = default)
        => Ok(await mediator.Send(query, cancellationToken));
}