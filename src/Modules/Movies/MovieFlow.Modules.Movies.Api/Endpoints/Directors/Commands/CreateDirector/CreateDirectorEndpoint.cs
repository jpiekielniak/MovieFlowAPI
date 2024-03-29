using MovieFlow.Modules.Movies.Application.Directors.Commands.CreateDirector;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Directors.Commands.CreateDirector;

[Route(DirectorEndpoint.Url)]
internal sealed class CreateDirectorEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<CreateDirectorEndpointRequest>
    .WithActionResult<CreateDirectorResponse>
{
    [Authorize(Roles = "Admin")]
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new director",
        Tags = [DirectorEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateDirectorResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(void))]
    public override async Task<ActionResult<CreateDirectorResponse>> HandleAsync(
        [FromForm] CreateDirectorEndpointRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = request.Command with { Photo = request.Photo };
        return Ok(await mediator.Send(command, cancellationToken));
    }
}