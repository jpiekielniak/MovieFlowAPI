using MovieFlow.Modules.Movies.Core.Movies.Entities;

namespace MovieFlow.Modules.Movies.Core.Movies.Repositories;

internal interface IActorRepository
{
    Task AddAsync(Actor actor, CancellationToken cancellationToken);
    Task<Actor> GetAsync(Guid actorId, CancellationToken cancellationToken);
}