using MovieFlow.Modules.Users.Application.Users.Queries.DTO;
using MovieFlow.Modules.Users.Application.Users.Queries.GetUser;
using MovieFlow.Shared.Abstractions.Exceptions.Errors;

namespace MovieFlow.Modules.Users.Api.Endpoints.User.Queries.GetUser;

[Route(UserEndpoint.Url)]
internal sealed class GetUserEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<GetUserQuery>
    .WithActionResult<UserDetailsDto?>
{
    [Authorize(Roles = "Admin")]
    [HttpGet("{userId:guid}")]
    [SwaggerOperation(
        Summary = "Get user details",
        Tags = [UserEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDetailsDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(void))]
    public override async Task<ActionResult<UserDetailsDto?>> HandleAsync(
        [FromRoute] GetUserQuery query,
        CancellationToken cancellationToken = new())
    {
        var user = await mediator.Send(query, cancellationToken);

        if (user is null)
            return NotFound();

        return Ok(user);
    }
}