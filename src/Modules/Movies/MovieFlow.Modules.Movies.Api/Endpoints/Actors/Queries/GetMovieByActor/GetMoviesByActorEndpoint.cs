using MovieFlow.Modules.Movies.Application.Actors.Queries.GetMoviesByActor;
using MovieFlow.Modules.Movies.Application.Actors.Queries.GetMoviesByActor.DTO;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Actors.Queries.GetMovieByActor;

[Route(ActorEndpoint.Url)]
internal sealed class GetMoviesByActorEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<Guid>
    .WithActionResult<List<ActorMovieDto>>
{
    [HttpGet("{actorId:guid}/movies")]
    [SwaggerOperation(
        Summary = "Get movies by actor Id",
        Tags = [ActorEndpoint.Tag]
    )]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ActorMovieDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    public override async Task<ActionResult<List<ActorMovieDto>>> HandleAsync(
        [FromRoute] Guid actorId,
        CancellationToken cancellationToken = default)
    {
        var query = new GetMoviesByActorQuery(actorId);
        return Ok(await mediator.Send(query, cancellationToken));
    }
}