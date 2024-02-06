using MediatR;
using MovieFlow.Modules.Movies.Application.Genres.DTO;

namespace MovieFlow.Modules.Movies.Application.Genres.Queries.Browse;

internal class BrowseGenresQuery : IRequest<List<BrowseGenresDto>>;
