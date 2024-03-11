namespace MovieFlow.Modules.Movies.Api.Endpoints.Movies.Commands.AddPhotoToMovie;

[Route(MovieEndpoint.Url)]
internal sealed class AddPhotoToMovieEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<AddPhotoToMovieEndpointRequest>
    .WithoutResult
{
    [Authorize(Roles = "Admin")]
    [HttpPost("{movieId:guid}/photos")]
    [SwaggerOperation(
        Summary = "Add photo to movie",
        Tags = [MovieEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(void))]
    public override async Task HandleAsync(AddPhotoToMovieEndpointRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = request.Command with { MovieId = request.MovieId };
        await mediator.Send(command, cancellationToken);
    }
}
