using MovieFlow.Modules.Movies.Application.Actors.Commands.CreateActor;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Actors.Commands.CreateActor;

[Route(ActorEndpoint.Url)]
internal sealed class CreateActorEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<CreateActorEndpointRequest>
    .WithActionResult<CreateActorResponse>
{
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [SwaggerOperation(
        Summary = "Create a new actor",
        Tags = [ActorEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateActorResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(void))]
    public override async Task<ActionResult<CreateActorResponse>> HandleAsync(CreateActorEndpointRequest request,
        CancellationToken cancellationToken = new())
    {
        var command = request.Command with { Photo = request.Photo };
        return await mediator.Send(command, cancellationToken);
    }
}