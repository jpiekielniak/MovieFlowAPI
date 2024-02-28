using MovieFlow.Modules.Movies.Application.Directors.Queries.GetMoviesForDirector;
using MovieFlow.Modules.Movies.Application.Directors.Queries.GetMoviesForDirector.DTO;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Directors.Queries.GetMoviesForDirector;

[Route(DirectorEndpoint.Url)]
internal sealed class GetMoviesForDirectorEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<Guid>
    .WithActionResult<List<DirectorMovieDto>>
{
    [HttpGet("{directorId:guid}/movies")]
    [SwaggerOperation(
        Summary = "Get movies for director",
        Tags = [DirectorEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DirectorMovieDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    public override async Task<ActionResult<List<DirectorMovieDto>>> HandleAsync(
        [FromRoute] Guid directorId,
        CancellationToken cancellationToken = default)
    {
        var query = new GetMoviesForDirectorQuery(directorId);
        return Ok(await mediator.Send(query, cancellationToken));
    }
}