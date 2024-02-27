using MovieFlow.Modules.Movies.Application.Genres.Commands.CreateGenre;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Genres.Commands.CreateGenre;

[Route(GenreEndpoint.Url)]
internal sealed class CreateGenreEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<CreateGenreCommand>
    .WithActionResult<CreateGenreResponse>
{
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [SwaggerOperation(
        Summary = "Create a new genre",
        Tags = [GenreEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateGenreResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(void))]
    public override async Task<ActionResult<CreateGenreResponse>> HandleAsync(CreateGenreCommand command,
        CancellationToken cancellationToken = default)
        => Ok(await mediator.Send(command, cancellationToken));
}