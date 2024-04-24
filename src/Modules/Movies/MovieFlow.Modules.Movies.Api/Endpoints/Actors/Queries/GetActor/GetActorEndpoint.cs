using MovieFlow.Modules.Movies.Application.Actors.Queries.GetActor;
using MovieFlow.Modules.Movies.Application.Actors.Queries.GetActor.DTO;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Actors.Queries.GetActor;

[Route(ActorEndpoint.Url)]
internal sealed class GetActorEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<Guid>
    .WithActionResult<ActorDetailsDto>
{
    [HttpGet("{actorId:guid}")]
    [SwaggerOperation(
        Summary = "Get actor by id",
        Tags = [ActorEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActorDetailsDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(void))]
    public override async Task<ActionResult<ActorDetailsDto>> HandleAsync(
        [FromRoute] Guid actorId,
        CancellationToken cancellationToken = new())
    {
        var query = new GetActorQuery(actorId);
        var actor = await mediator.Send(query, cancellationToken);
        return actor is null ? NotFound() : Ok(actor);
    }
}