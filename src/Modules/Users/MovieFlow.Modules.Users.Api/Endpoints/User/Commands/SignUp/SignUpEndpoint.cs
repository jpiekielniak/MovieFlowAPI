using MovieFlow.Modules.Users.Application.Users.Commands.SignUp;

namespace MovieFlow.Modules.Users.Api.Endpoints.User.Commands.SignUp;

[Route(UserEndpoint.Url)]
internal sealed class SignUpEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<SignUpCommand>
    .WithActionResult<SignUpResponse>
{
    [AllowAnonymous]
    [HttpPost("sign-up")]
    [SwaggerOperation(
        Summary = "Sign up",
        Tags = [UserEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public override async Task<ActionResult<SignUpResponse>> HandleAsync(SignUpCommand command,
        CancellationToken cancellationToken = default)
        => Ok(await mediator.Send(command, cancellationToken));
}