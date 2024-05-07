namespace MovieFlow.Modules.Movies.Api.Endpoints.Movies.Commands.DeleteActorFromMovie;

[Route(MovieEndpoint.Url)]
internal sealed class DeleteActorFromMovieEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<DeleteActorFromMovieEndpointRequest>
    .WithoutResult
{
    [Authorize(Roles = "Admin")]
    [HttpDelete("{movieId:guid}/actors")]
    [SwaggerOperation(
        Summary = "Delete an actor from a movie",
        Tags = [MovieEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(void))]
    public override async Task HandleAsync(
        DeleteActorFromMovieEndpointRequest request, 
        CancellationToken cancellationToken = default)
    {
        var command = request.Command with { MovieId = request.MovieId };
        await mediator.Send(command, cancellationToken);
    }
}