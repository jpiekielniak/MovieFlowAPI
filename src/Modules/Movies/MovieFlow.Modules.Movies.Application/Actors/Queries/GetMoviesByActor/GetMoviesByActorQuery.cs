using MovieFlow.Modules.Movies.Application.Actors.Queries.GetMoviesByActor.DTO;

namespace MovieFlow.Modules.Movies.Application.Actors.Queries.GetMoviesByActor;

internal record GetMoviesByActorQuery(Guid ActorId) : IRequest<List<ActorMovieDto>>;