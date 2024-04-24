using MovieFlow.Modules.Movies.Application.Actors.Queries.GetActor.DTO;

namespace MovieFlow.Modules.Movies.Application.Actors.Queries.GetActor;

internal record GetActorQuery(Guid ActorId) : IRequest<ActorDetailsDto>;