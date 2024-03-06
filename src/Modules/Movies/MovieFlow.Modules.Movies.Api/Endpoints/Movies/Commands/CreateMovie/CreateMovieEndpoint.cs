using MovieFlow.Modules.Movies.Application.Movies.Commands.CreateMovie;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Movies.Commands.CreateMovie;

[Route($"{MovieEndpoint.Url}")]
internal sealed class CreateMovieEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<CreateMovieEndpointRequest>
    .WithResult<CreateMovieResponse>
{
    [Authorize(Roles = "Admin")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateMovieResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(void))]
    [SwaggerOperation(
        Summary = "Create Movie",
        Tags = [MovieEndpoint.Tag]
    )]
    public override async Task<CreateMovieResponse> HandleAsync(
        [FromForm] CreateMovieEndpointRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = request.Command with { Photo = request.Photo };
        return await mediator.Send(command, cancellationToken);
    }
}