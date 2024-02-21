using MovieFlow.Modules.Users.Application.Users.Commands.DeleteUser;
using MovieFlow.Shared.Abstractions.Exceptions.Errors;

namespace MovieFlow.Modules.Users.Api.Endpoints.User.Commands.DeleteUser;

[Route(UserEndpoint.Url)]
internal sealed class DeleteUserEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<Guid>
    .WithoutResult
{
    [Authorize(Roles = "Admin")]
    [HttpDelete("{userId:guid}")]
    [SwaggerOperation(
        Summary = "Delete user",
        Tags = [UserEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(void))]
    public override async Task HandleAsync([FromRoute] Guid userId,
        CancellationToken cancellationToken = default)
        => await mediator.Send(new DeleteUserCommand(userId), cancellationToken);
}