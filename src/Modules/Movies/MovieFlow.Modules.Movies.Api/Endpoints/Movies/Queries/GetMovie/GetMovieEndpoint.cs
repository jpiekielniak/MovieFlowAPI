using MovieFlow.Modules.Movies.Application.Movies.Queries.GetMovie;
using MovieFlow.Modules.Movies.Application.Movies.Queries.GetMovie.DTO;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Movies.Queries.GetMovie;

[Route($"{MovieEndpoint.Url}")]
internal sealed class GetMovieEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<Guid>
    .WithActionResult<MovieDetailsDto>
{
    [HttpGet("{movieId:guid}")]
    [SwaggerOperation(
        Summary = "Get a movie by id",
        Tags = [MovieEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieDetailsDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(void))]
    public override async Task<ActionResult<MovieDetailsDto>> HandleAsync(
        [FromRoute] Guid movieId,
        CancellationToken cancellationToken = default)
    {
        var query = new GetMovieQuery(movieId);
        var movie = await mediator.Send(query, cancellationToken);

        if (movie is null)
            return NotFound();

        return Ok(movie);
    }
}