using MovieFlow.Modules.Movies.Application.Actors.Commands.DeleteActor;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Actors.Commands.DeleteActor;

[Route(ActorEndpoint.Url)]
internal sealed class DeleteActorEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<Guid>
    .WithoutResult
{
    [Authorize(Roles = "Admin")]
    [HttpDelete("{actorId:guid}")]
    [SwaggerOperation(
        Summary = "Delete an actor",
        Tags = [ActorEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(void))]
    public override async Task HandleAsync(Guid actorId, 
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteActorCommand(actorId);
        await mediator.Send(command, cancellationToken);
    }
}