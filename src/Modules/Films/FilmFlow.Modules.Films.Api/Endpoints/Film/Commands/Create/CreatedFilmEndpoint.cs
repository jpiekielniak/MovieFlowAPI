using FilmFlow.Modules.Films.Application.Films.Commands.Create;

namespace FilmFlow.Modules.Films.Api.Endpoints.Film.Commands.Create;

[Route($"{FilmsEndpoint.Url}")]
internal sealed class CreatedFilmEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<CreateFilmCommand>
    .WithResult<CreateFilmResponse>
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(
        Summary = "Create Film",
        Tags = [FilmsEndpoint.Tag]
    )]
    public override async Task<CreateFilmResponse> HandleAsync(CreateFilmCommand command,
        CancellationToken cancellationToken = default)
        => await mediator.Send(command, cancellationToken);
}