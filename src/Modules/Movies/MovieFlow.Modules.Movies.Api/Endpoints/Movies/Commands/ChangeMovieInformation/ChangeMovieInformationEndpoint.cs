using MovieFlow.Shared.Infrastructure.Api.Attributes;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Movies.Commands.ChangeMovieInformation;

[Route($"{MovieEndpoint.Url}")]
internal sealed class ChangeMovieInformationEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<ChangeMovieInformationRequest>
    .WithoutResult
{
    [Authorize(Roles = "Admin")]
    [HttpPut("{movieId:guid}")]
    [SwaggerOperation(
        Summary = "Change movie information",
        Tags = [MovieEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(void))]
    public override async Task HandleAsync(
        [FromRequestSource] ChangeMovieInformationRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = request.Command with { MovieId = request.MovieId };
        await mediator.Send(command, cancellationToken);
    }
}