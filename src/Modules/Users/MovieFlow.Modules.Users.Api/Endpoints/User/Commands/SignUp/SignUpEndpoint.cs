using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieFlow.Modules.Users.Application.Users.Commands.SignUp;
using Swashbuckle.AspNetCore.Annotations;

namespace MovieFlow.Modules.Users.Api.Endpoints.User.Commands.SignUp;

[Route(UsersEndpoint.Url)]
internal sealed class SignUpEndpoint(
    IMediator mediator) : EndpointBaseAsync
    .WithRequest<SignUpCommand>
    .WithActionResult<SignUpResponse>
{
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