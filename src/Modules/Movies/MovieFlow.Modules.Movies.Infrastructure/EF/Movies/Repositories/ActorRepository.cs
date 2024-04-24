using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Repositories;

internal sealed class ActorRepository(MoviesWriteDbContext dbContext) : IActorRepository
{
    private readonly DbSet<Actor> _actors = dbContext.Actors;
    
    public async Task AddAsync(Actor actor, CancellationToken cancellationToken)
    {
        await _actors.AddAsync(actor, cancellationToken);
        await CommitAsync(cancellationToken);
    }

    private async Task CommitAsync(CancellationToken cancellationToken)
        => await dbContext.SaveChangesAsync(cancellationToken);
}