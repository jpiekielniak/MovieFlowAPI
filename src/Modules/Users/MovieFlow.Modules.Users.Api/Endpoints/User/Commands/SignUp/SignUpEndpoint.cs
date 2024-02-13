using MovieFlow.Modules.Users.Application.Users.Commands.SignUp;

namespace MovieFlow.Modules.Users.Api.Endpoints.User.Commands.SignUp;

[Route(UsersEndpoint.Url)]
internal sealed class SignUpEndpoint(
    IMediator mediator) : EndpointBaseAsync
    .WithRequest<SignUpCommand>
    .WithActionResult<SignUpResponse>
{
    [AllowAnonymous]
    [HttpPost("sign-up")]
    [SwaggerOperation(
        Summary = "Sign up",
        Tags = [UsersEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public override async Task<ActionResult<SignUpResponse>> HandleAsync(SignUpCommand command,
        CancellationToken cancellationToken = new())
        => Ok(await mediator.Send(command, cancellationToken));
}