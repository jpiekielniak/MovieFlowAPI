using Microsoft.AspNetCore.Authorization;
using MovieFlow.Shared.Infrastructure.Api.Attributes;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Review.Commands.ChangeInformation;

[Route(MoviesEndpoint.Url)]
internal sealed class ChangeReviewInformationEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<ChangeReviewInformationEndpointRequest>
    .WithoutResult
{
    [Authorize]
    [HttpPut("{movieId:guid}/reviews/{reviewId:guid}")]
    [SwaggerOperation(
        Summary = "Change review",
        Tags = [ReviewsEndpoint.Tag]
    )]
    public override async Task HandleAsync(
        [FromRequestSource] ChangeReviewInformationEndpointRequest request,
        CancellationToken cancellationToken = new())
        => await mediator.Send(request.Command with { MovieId = request.MovieId, ReviewId = request.ReviewId },
            cancellationToken);
}