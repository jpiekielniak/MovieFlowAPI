using MediatR;
using MovieFlow.Modules.Movies.Application.Movies.Queries.Browse.DTO;

namespace MovieFlow.Modules.Movies.Application.Movies.Queries.Browse;

internal class BrowseMoviesQuery : IRequest<List<MovieDto>>
{
    public string? Title { get; set; }
    public int? ReleaseYear { get; set; }
}