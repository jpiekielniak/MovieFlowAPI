using MovieFlow.Modules.Movies.Shared.DTO;
using MovieFlow.Modules.Users.Application.Users.Queries.GetReviewForUser;
using MovieFlow.Shared.Abstractions.Exceptions.Errors;

namespace MovieFlow.Modules.Users.Api.Endpoints.User.Queries.GetReviewForUser;

[Route(UserEndpoint.Url)]
internal sealed class GetReviewForUserEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<GetReviewForUserQuery>
    .WithActionResult<List<ReviewUserDto>>
{
    [Authorize]
    [HttpGet("{userId:guid}/reviews")]
    [SwaggerOperation(
        Summary = "Get reviews for user",
        Tags = [UserEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ReviewUserDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    public override async Task<ActionResult<List<ReviewUserDto>>> HandleAsync(
        [FromRoute] GetReviewForUserQuery query,
        CancellationToken cancellationToken = new())
        => Ok(await mediator.Send(query, cancellationToken));
}