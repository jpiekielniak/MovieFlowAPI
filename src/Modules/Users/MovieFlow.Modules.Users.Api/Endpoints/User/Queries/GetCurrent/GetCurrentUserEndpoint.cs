using MovieFlow.Modules.Users.Application.Users.Queries.DTO;
using MovieFlow.Modules.Users.Application.Users.Queries.GetCurrent;

namespace MovieFlow.Modules.Users.Api.Endpoints.User.Queries.GetCurrent;

[Route(UsersEndpoint.Url)]
internal sealed class GetCurrentUserEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<UserDetailsDto>
{
    [Authorize]
    [HttpGet("user")]
    [SwaggerOperation(
        Summary = "Get current logged user",
        Tags = [UsersEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDetailsDto))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(void))]
    public override async Task<ActionResult<UserDetailsDto>> HandleAsync(
        CancellationToken cancellationToken = new())
    {
        var response = await mediator.Send(new GetCurrentUserQuery(), cancellationToken);

        if (response is null)
            return NotFound();

        return Ok(response);
    }
}