using FilmFlow.Modules.Films.Application.Films.Queries.Browse;
using FilmFlow.Modules.Films.Application.Films.Queries.Browse.DTO;

namespace FilmFlow.Modules.Films.Api.Endpoints.Film.Queries.Browse;

[Route($"{FilmsEndpoint.Url}")]
internal sealed class BrowseFilmsEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<BrowseFilmsQuery>
    .WithActionResult<List<FilmDto>>
{
    [HttpGet]
    [SwaggerOperation(
        Summary = "Browse Films",
        Tags = [FilmsEndpoint.Tag]
    )]
    [SwaggerResponse(StatusCodes.Status200OK)]
    public override async Task<ActionResult<List<FilmDto>>> HandleAsync(
        [FromQuery] BrowseFilmsQuery query,
        CancellationToken cancellationToken = default)
        => Ok(await mediator.Send(query, cancellationToken));
}