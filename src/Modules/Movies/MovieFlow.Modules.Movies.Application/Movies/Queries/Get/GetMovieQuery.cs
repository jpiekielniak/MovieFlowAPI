using MovieFlow.Modules.Movies.Application.Movies.Queries.Get.DTO;

namespace MovieFlow.Modules.Movies.Application.Movies.Queries.Get;

internal record GetMovieQuery(Guid Id) : IRequest<MovieDetailsDto>;
