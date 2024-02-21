using MovieFlow.Modules.Movies.Application.Genres.Queries.Browse.DTO;

namespace MovieFlow.Modules.Movies.Application.Genres.Queries.Browse;

internal record BrowseGenresQuery : IRequest<List<BrowseGenresDto>>;
