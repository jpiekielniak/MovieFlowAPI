using MovieFlow.Modules.Movies.Application.Genres.Commands.DeleteGenre;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Genres.Commands.DeleteGenre;

[Route(GenreEndpoint.Url)]
internal sealed class DeleteGenreEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<Guid>
    .WithoutResult
{
    [Authorize(Roles = "Admin")]
    [HttpDelete("{genreId:guid}")]
    [SwaggerOperation(
        Summary = "Delete a genre",
        Tags = [GenreEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(void))]
    public override async Task HandleAsync(
        [FromRoute] Guid genreId,
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteGenreCommand(genreId);
        await mediator.Send(command, cancellationToken);
    }
}