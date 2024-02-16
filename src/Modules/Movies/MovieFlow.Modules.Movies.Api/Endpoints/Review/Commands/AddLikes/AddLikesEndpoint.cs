using Microsoft.AspNetCore.Authorization;
using MovieFlow.Shared.Infrastructure.Api.Attributes;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Review.Commands.AddLikes;

[Route(MoviesEndpoint.Url)]
internal sealed class AddLikesEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<AddLikesEndpointRequest>
    .WithoutResult
{
    [Authorize]
    [HttpPatch("{movieId:guid}/reviews/{reviewId:guid}/likes")]
    [SwaggerOperation(
        Summary = "Adds likes to review.",
        Tags = [ReviewsEndpoint.Tag]
    )]
    [SwaggerResponse(StatusCodes.Status204NoContent, Type = typeof(void))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    public override async Task HandleAsync(
        [FromRequestSource] AddLikesEndpointRequest request,
        CancellationToken cancellationToken = new())
        => await mediator.Send(request.Command with { MovieId = request.MovieId, ReviewId = request.ReviewId },
            cancellationToken);
}