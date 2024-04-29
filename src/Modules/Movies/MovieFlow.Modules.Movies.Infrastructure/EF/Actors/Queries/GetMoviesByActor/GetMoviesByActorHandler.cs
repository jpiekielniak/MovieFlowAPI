using MovieFlow.Modules.Movies.Application.Actors.Queries.GetMoviesByActor;
using MovieFlow.Modules.Movies.Application.Actors.Queries.GetMoviesByActor.DTO;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Actors;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Actors.Queries.GetMoviesByActor;

internal sealed class GetMoviesByActorHandler(MoviesReadDbContext readDbContext)
    : IRequestHandler<GetMoviesByActorQuery, List<ActorMovieDto>>
{
    public async Task<List<ActorMovieDto>> Handle(GetMoviesByActorQuery query,
        CancellationToken cancellationToken)
    {
        var actorExists = await readDbContext.Actors
            .AnyAsync(x => x.Id == query.ActorId, cancellationToken);

        if (!actorExists)
            throw new ActorNotFoundException(query.ActorId);

        var movies = await readDbContext.Movies
            .AsNoTracking()
            .Include(x => x.Photos)
            .Include(x => x.Actors)
            .Where(x => x.Actors.Any(a => a.Id == query.ActorId))
            .ToListAsync(cancellationToken);

        return movies
            .Select(x => x.AsActorMovieDto())
            .ToList();
    }
}