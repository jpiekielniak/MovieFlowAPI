using MovieFlow.Modules.Movies.Application.Movies.Commands.DeleteMovie;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Movies.Commands.DeleteMovie;

[Route(MovieEndpoint.Url)]
internal sealed class DeleteMovieEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<Guid>
    .WithActionResult
{
    [Authorize(Roles = "Admin")]
    [HttpDelete("{movieId:guid}")]
    [SwaggerOperation(
        Summary = "Deletes a movie",
        Tags = [MovieEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(void))]
    public override async Task<ActionResult> HandleAsync([FromRoute] Guid movieId,
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteMovieCommand(movieId);
        await mediator.Send(command, cancellationToken);
        return NoContent();
    }
}