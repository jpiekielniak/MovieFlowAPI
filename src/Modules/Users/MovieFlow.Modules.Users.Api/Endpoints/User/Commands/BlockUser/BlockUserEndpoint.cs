using MovieFlow.Modules.Users.Application.Users.Commands.BlockUser;

namespace MovieFlow.Modules.Users.Api.Endpoints.User.Commands.BlockUser;

[Route(UserEndpoint.Url)]
internal sealed class BlockUserEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<Guid>
    .WithActionResult
{
    [Authorize(Roles = "Admin")]
    [HttpPost("{userId:guid}/block")]
    [SwaggerOperation(
        Summary = "Block user by id",
        Tags = [UserEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(void))]
    public override async Task<ActionResult> HandleAsync(Guid userId,
        CancellationToken cancellationToken = default)
    {
        var command = new BlockUserCommand(userId);
        await mediator.Send(command, cancellationToken);
        return Ok();
    }
}