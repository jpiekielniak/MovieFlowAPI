using Microsoft.AspNetCore.Authorization;
using MovieFlow.Shared.Infrastructure.Api.Attributes;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Review.Commands.ChangeReview;

[Route(MoviesEndpoint.Url)]
internal sealed class ChangeReviewEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<ChangeReviewEndpointRequest>
    .WithoutResult
{
    [Authorize]
    [HttpPut("{movieId:guid}/reviews/{reviewId:guid}")]
    [SwaggerOperation(
        Summary = "Change review",
        Tags = [ReviewsEndpoint.Tag]
    )]
    public override async Task HandleAsync(
        [FromRequestSource] ChangeReviewEndpointRequest request,
        CancellationToken cancellationToken = new())
        => await mediator.Send(request.Command with { MovieId = request.MovieId, ReviewId = request.ReviewId },
            cancellationToken);
}