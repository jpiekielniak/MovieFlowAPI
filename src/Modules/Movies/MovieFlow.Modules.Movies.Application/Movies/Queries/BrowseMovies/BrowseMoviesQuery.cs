using MovieFlow.Modules.Movies.Application.Movies.Queries.BrowseMovies.DTO;

namespace MovieFlow.Modules.Movies.Application.Movies.Queries.BrowseMovies;

internal class BrowseMoviesQuery : IRequest<List<MovieDto>>
{
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    public string Genre { get; set; }
    public string Director { get; set; }
}