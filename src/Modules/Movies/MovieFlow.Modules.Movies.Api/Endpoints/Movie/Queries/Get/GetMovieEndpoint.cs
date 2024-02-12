using MovieFlow.Modules.Movies.Application.Movies.Queries.Get;
using MovieFlow.Modules.Movies.Application.Movies.Queries.Get.DTO;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Movie.Queries.Get;

[Route($"{MoviesEndpoint.Url}")]
internal sealed class GetMovieEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<GetMovieQuery>
    .WithActionResult<MovieDetailsDto>
{
    [HttpGet("{movieId:guid}")]
    [SwaggerOperation(
        Summary = "Get a movie by id",
        Tags = [MoviesEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MovieDetailsDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public override async Task<ActionResult<MovieDetailsDto>> HandleAsync(
        [FromRoute] GetMovieQuery query,
        CancellationToken cancellationToken = new())
    {
        var movie = await mediator.Send(query, cancellationToken);

        if (movie is null)
            return NotFound();

        return Ok(movie);
    }
}