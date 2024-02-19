using MovieFlow.Shared.Abstractions.Exceptions.Errors;

namespace MovieFlow.Modules.Users.Api.Endpoints.User.Commands.Delete;

[Route(UsersEndpoint.Url)]
internal sealed class DeleteUserEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<DeleteUserCommand>
    .WithoutResult
{
    [Authorize(Roles = "Admin")]
    [HttpDelete("{userId:guid}")]
    [SwaggerOperation(
        Summary = "Delete user",
        Tags = [UsersEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(void))]
    public override async Task HandleAsync(DeleteUserCommand command,
        CancellationToken cancellationToken = new())
        => await mediator.Send(command, cancellationToken);
}