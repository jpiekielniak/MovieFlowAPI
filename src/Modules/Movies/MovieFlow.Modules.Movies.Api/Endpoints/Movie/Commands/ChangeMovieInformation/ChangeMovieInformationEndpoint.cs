using MovieFlow.Shared.Infrastructure.Api.Attributes;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Movie.Commands.ChangeMovieInformation;

[Route($"{MoviesEndpoint.Url}")]
internal sealed class ChangeMovieInformationEndpoint(
    IMediator mediator) : EndpointBaseAsync
    .WithRequest<ChangeMovieInformationRequest>
    .WithoutResult
{
    [HttpPut("{movieId:guid}")]
    [SwaggerOperation(
        Summary = "Change movie information",
        Tags = [MoviesEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status400BadRequest)]
    public override async Task HandleAsync(
        [FromRequestSource] ChangeMovieInformationRequest request,
        CancellationToken cancellationToken = new())
        => await mediator.Send(request.Command with { MovieId = request.MovieId }, cancellationToken);
}