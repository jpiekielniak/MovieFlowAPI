using MovieFlow.Modules.Movies.Application.Movies.Queries.GetTheNearestCinemas;
using MovieFlow.Modules.Movies.GoogleMaps.Services.DTO;

namespace MovieFlow.Modules.Movies.Api.Cinemas.Queries.GetTheNearestCinema;

[Route(CinemaEndpoint.Url)]
internal sealed class GetTheNearestCinemasEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<GetTheNearestCinemasQuery>
    .WithActionResult<List<CinemaDto>>
{
    [AllowAnonymous]
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get the nearest cinema",
        Tags = [CinemaEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CinemaDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    public override async Task<ActionResult<List<CinemaDto>>> HandleAsync(
        [FromQuery] GetTheNearestCinemasQuery query,
        CancellationToken cancellationToken = default)
        => Ok(await mediator.Send(query, cancellationToken));
}