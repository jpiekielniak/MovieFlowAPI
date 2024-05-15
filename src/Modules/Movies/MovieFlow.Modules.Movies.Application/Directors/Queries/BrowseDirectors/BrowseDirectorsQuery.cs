using MovieFlow.Modules.Movies.Application.Movies.Queries.BrowseMovies.DTO;

namespace MovieFlow.Modules.Movies.Application.Directors.Queries.BrowseDirectors;

internal class BrowseDirectorsQuery : IRequest<List<BrowseDirectorDto>>
{
    public string Name { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Country { get; set; }
}