using MovieFlow.Modules.Movies.Application.Actors.Queries.GetActor;
using MovieFlow.Modules.Movies.Application.Actors.Queries.GetActor.DTO;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;
using MovieFlow.Modules.Movies.Infrastructure.EF.Directors.Queries;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Actors.Queries.GetActor;

internal sealed class GetActorHandler(MoviesReadDbContext readDbContext)
    : IRequestHandler<GetActorQuery, ActorDetailsDto>
{
    public async Task<ActorDetailsDto> Handle(GetActorQuery query, CancellationToken cancellationToken)
    {
        var actor = await readDbContext.Actors
            .Include(x => x.Photos)
            .Include(x => x.Movies)
            .ThenInclude(x => x.Photos)
            .SingleOrDefaultAsync(x => x.Id == query.ActorId, cancellationToken);

        return actor?.AsDetailsDto();
    }
}