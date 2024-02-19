using MovieFlow.Modules.Movies.Shared.DTO;
using MovieFlow.Modules.Users.Application.Users.Queries.DTO;
using MovieFlow.Modules.Users.Application.Users.Queries.GetReviewForUser;
using MovieFlow.Shared.Abstractions.Exceptions.Errors;

namespace MovieFlow.Modules.Users.Api.Endpoints.User.Queries.GetReviewForUser;

[Route(UsersEndpoint.Url)]
internal sealed class GetReviewForUserEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<GetReviewForUserQuery>
    .WithActionResult<List<ReviewUserDto>>
{
    [Authorize]
    [HttpGet("{userId:guid}/reviews")]
    [SwaggerOperation(
        Summary = "Get reviews for user",
        Tags = [UsersEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ReviewDto>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    public override async Task<ActionResult<List<ReviewUserDto>>> HandleAsync(
        [FromRoute] GetReviewForUserQuery query,
        CancellationToken cancellationToken = new())
        => Ok(await mediator.Send(query, cancellationToken));
}