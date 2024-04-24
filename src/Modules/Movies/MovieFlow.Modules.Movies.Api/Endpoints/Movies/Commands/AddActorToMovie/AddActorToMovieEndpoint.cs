using MovieFlow.Shared.Infrastructure.Api.Attributes;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Movies.Commands.AddActorToMovie;

[Route(MovieEndpoint.Url)]
internal sealed class AddActorToMovieEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<AddActorToMovieEndpointRequest>
    .WithoutResult
{
    [Authorize(Roles = "Admin")]
    [HttpPost("{movieId:guid}/actors")]
    [SwaggerOperation(
        Summary = "Add actor to movie",
        Tags = [MovieEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(void))]
    public override async Task HandleAsync(
        [FromRequestSource] AddActorToMovieEndpointRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = request.Command with { MovieId = request.MovieId };
        await mediator.Send(command, cancellationToken);
    }
}
