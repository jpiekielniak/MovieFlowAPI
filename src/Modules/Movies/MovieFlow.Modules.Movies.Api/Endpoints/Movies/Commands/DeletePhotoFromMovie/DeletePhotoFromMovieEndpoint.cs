namespace MovieFlow.Modules.Movies.Api.Endpoints.Movies.Commands.DeletePhotoFromMovie;

[Route(MovieEndpoint.Url)]
internal sealed class DeletePhotoFromMovieEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<DeletePhotoFromMovieEndpointRequest>
    .WithoutResult
{
    [Authorize(Roles = "Admin")]
    [HttpDelete("{movieId:guid}/photos")]
    [SwaggerOperation(
        Summary = "Delete photo",
        Tags = [MovieEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(void))]
    public override async Task HandleAsync(DeletePhotoFromMovieEndpointRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = request.Command with { MovieId = request.MovieId };
        await mediator.Send(command, cancellationToken);
    }
}