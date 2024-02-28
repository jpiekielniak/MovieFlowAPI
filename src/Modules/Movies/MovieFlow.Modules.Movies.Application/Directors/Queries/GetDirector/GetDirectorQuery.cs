using MovieFlow.Modules.Movies.Application.Directors.Queries.DTO;

namespace MovieFlow.Modules.Movies.Application.Directors.Queries.GetDirector;

internal record GetDirectorQuery(Guid DirectorId) : IRequest<DirectorDetailsDto>;