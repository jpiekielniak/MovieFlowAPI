using MovieFlow.Modules.Movies.Application.Genres.Queries.BrowseGenres.DTO;

namespace MovieFlow.Modules.Movies.Application.Genres.Queries.BrowseGenres;

internal record BrowseGenresQuery : IRequest<List<BrowseGenresDto>>;
