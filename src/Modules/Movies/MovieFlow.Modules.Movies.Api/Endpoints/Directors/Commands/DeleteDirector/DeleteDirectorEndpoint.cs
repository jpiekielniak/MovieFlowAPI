namespace MovieFlow.Modules.Movies.Api.Endpoints.Directors.Commands.DeleteDirector;

[Route(DirectorEndpoint.Url)]
internal sealed class DeleteDirectorEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<Guid>
    .WithoutResult
{
    [Authorize(Roles = "Admin")]
    [HttpDelete("{directorId:guid}")]
    [SwaggerOperation(
        Summary = "Deletes a director.",
        Tags = [DirectorEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(void))]
    public override async Task HandleAsync([FromRoute] Guid directorId,
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteDirectorCommand(directorId);
        await mediator.Send(command, cancellationToken);
    }
}