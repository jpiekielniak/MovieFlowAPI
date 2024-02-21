using MovieFlow.Modules.Users.Application.Users.Queries.DTO;
using MovieFlow.Modules.Users.Application.Users.Queries.GetCurrentLoggedUser;

namespace MovieFlow.Modules.Users.Api.Endpoints.User.Queries.GetCurrentLoggedUser;

[Route(UserEndpoint.Url)]
internal sealed class GetCurrentLoggedUserEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<UserDetailsDto>
{
    [Authorize]
    [HttpGet("users")]
    [SwaggerOperation(
        Summary = "Get current logged user",
        Tags = [UserEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDetailsDto))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(void))]
    public override async Task<ActionResult<UserDetailsDto>> HandleAsync(
        CancellationToken cancellationToken = default)
    {
        var response = await mediator.Send(new GetCurrentLoggedUserQuery(), cancellationToken);

        if (response is null)
            return NotFound();

        return Ok(response);
    }
}