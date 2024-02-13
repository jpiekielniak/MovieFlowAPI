using MovieFlow.Modules.Users.Application.Users.Commands.SignIn;

namespace MovieFlow.Modules.Users.Api.Endpoints.User.Commands.SignIn;

[Route(UsersEndpoint.Url)]
internal sealed class SignInEndpoint(
    IMediator mediator) : EndpointBaseAsync
    .WithRequest<SignInCommand>
    .WithActionResult<SignInResponse>
{
    [AllowAnonymous]
    [HttpPost("sign-in")]
    [SwaggerOperation(
        Summary = "Sign in",
        Tags = [UsersEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public override async Task<ActionResult<SignInResponse>> HandleAsync(SignInCommand command,
        CancellationToken cancellationToken = new())
        => Ok(await mediator.Send(command, cancellationToken));
}