using MovieFlow.Modules.Movies.Application.Shared.DTO;

namespace MovieFlow.Modules.Movies.Application.Directors.Queries.BrowseDirectors;

internal class BrowseDirectorsQuery : IRequest<List<DirectorDto>>
{
    public string Name { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Country { get; set; }
}