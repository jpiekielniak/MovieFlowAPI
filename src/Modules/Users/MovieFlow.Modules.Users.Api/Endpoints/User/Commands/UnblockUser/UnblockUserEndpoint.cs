using MovieFlow.Modules.Users.Application.Users.Commands.UnblockUser;

namespace MovieFlow.Modules.Users.Api.Endpoints.User.Commands.UnblockUser;

[Route(UserEndpoint.Url)]
internal sealed class UnblockUserEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<Guid>
    .WithActionResult
{
    [Authorize(Roles = "Admin")]
    [HttpPost("{userId:guid}/unblock")]
    [SwaggerOperation(
        Summary = "Unblock user by id",
        Tags = [UserEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(void))]
    public override async Task<ActionResult> HandleAsync(Guid userId,
        CancellationToken cancellationToken = default)
    {
        var command = new UnblockUserCommand(userId);
        await mediator.Send(command, cancellationToken);
        return Ok();
    }
}