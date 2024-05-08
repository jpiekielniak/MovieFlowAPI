using MovieFlow.Modules.Movies.Application.Directors.Queries.DTO;
using MovieFlow.Modules.Movies.Application.Directors.Queries.GetDirector;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Directors.Queries.GetDirector;

[Route(DirectorEndpoint.Url)]
internal sealed class GetDirectorEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<Guid>
    .WithActionResult<DirectorDetailsDto>
{
    [HttpGet("{directorId:guid}")]
    [SwaggerOperation(
        Summary = "Get director details",
        Tags = [DirectorEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DirectorDetailsDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(void))]
    public override async Task<ActionResult<DirectorDetailsDto>> HandleAsync(
        [FromRoute] Guid directorId,
        CancellationToken cancellationToken = default)
    {
        var query = new GetDirectorQuery(directorId);
        var response = await mediator.Send(query, cancellationToken);

        if (response is null)
            return NotFound();

        return Ok(response);
    }
}