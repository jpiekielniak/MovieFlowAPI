using MovieFlow.Modules.Users.Application.Users.Commands.ChangePassword;
using MovieFlow.Shared.Abstractions.Exceptions.Errors;

namespace MovieFlow.Modules.Users.Api.Endpoints.User.Commands.ChangePassword;

[Route(UserEndpoint.Url)]
internal sealed class ChangePasswordEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<ChangePasswordCommand>
    .WithoutResult
{
    [Authorize]
    [HttpPut("password")]
    [SwaggerOperation(
        Summary = "Change user password",
        Tags = [UserEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    public override async Task HandleAsync(ChangePasswordCommand command,
        CancellationToken cancellationToken = default)
        => await mediator.Send(command, cancellationToken);
}