using MovieFlow.Modules.Movies.Api.Endpoints.Movies;
using MovieFlow.Shared.Infrastructure.Api.Attributes;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Reviews.Commands.ChangeReviewInformation;

[Route(MovieEndpoint.Url)]
internal sealed class ChangeReviewInformationEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<ChangeReviewInformationEndpointRequest>
    .WithoutResult
{
    [Authorize]
    [HttpPut("{movieId:guid}/reviews/{reviewId:guid}")]
    [SwaggerOperation(
        Summary = "Change review",
        Tags = [ReviewEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    public override async Task HandleAsync(
        [FromRequestSource] ChangeReviewInformationEndpointRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = request.Command with
        {
            MovieId = request.MovieId,
            ReviewId = request.ReviewId
        };

        await mediator.Send(command, cancellationToken);
    }
}