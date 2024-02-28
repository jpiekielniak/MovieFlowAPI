using MovieFlow.Modules.Movies.Application.Genres.Queries.BrowseGenres;
using MovieFlow.Modules.Movies.Application.Genres.Queries.BrowseGenres.DTO;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Genres.Queries.BrowseGenres;

[Route($"{GenreEndpoint.Url}")]
internal sealed class BrowseGenresEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<List<BrowseGenresDto>>
{
    [HttpGet]
    [SwaggerOperation(
        Summary = "Browse Genres",
        Tags = [GenreEndpoint.Tag]
    )]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<BrowseGenresDto>))]
    public override async Task<ActionResult<List<BrowseGenresDto>>> HandleAsync(
        CancellationToken cancellationToken = default)
        => Ok(await mediator.Send(new BrowseGenresQuery(), cancellationToken));
}