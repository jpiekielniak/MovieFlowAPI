using MovieFlow.Modules.Movies.Application.Movies.Commands.Create;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Movie.Commands.Create;

[Route($"{MoviesEndpoint.Url}")]
internal sealed class CreateMovieEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<CreateMovieCommand>
    .WithResult<CreateMovieResponse>
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(
        Summary = "Create Movie",
        Tags = [MoviesEndpoint.Tag]
    )]
    public override async Task<CreateMovieResponse> HandleAsync(CreateMovieCommand command,
        CancellationToken cancellationToken = default)
        => await mediator.Send(command, cancellationToken);
}