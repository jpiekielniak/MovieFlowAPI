using MovieFlow.Shared.Infrastructure.Api.Attributes;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Directors.Commands.ChangeDirectorInformation;

[Route(DirectorEndpoint.Url)]
internal sealed class ChangeDirectorInformationEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<ChangeDirectorInformationEndpointRequest>
    .WithoutResult
{
    [Authorize(Roles = "Admin")]
    [HttpPut("{directorId:guid}")]
    [SwaggerOperation(
        Summary = "Change director information",
        Tags = [DirectorEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(void))]
    public override async Task HandleAsync(
        [FromRequestSource] ChangeDirectorInformationEndpointRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = request.Command with { DirectorId = request.DirectorId };
        await mediator.Send(command, cancellationToken);
    }
}