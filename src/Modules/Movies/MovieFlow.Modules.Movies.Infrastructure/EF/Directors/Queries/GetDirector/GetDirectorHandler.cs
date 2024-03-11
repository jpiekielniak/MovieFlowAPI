using MovieFlow.Modules.Movies.Application.Directors.Queries.DTO;
using MovieFlow.Modules.Movies.Application.Directors.Queries.GetDirector;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Directors;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Directors.Queries.GetDirector;

internal sealed class GetDirectorHandler(MoviesReadDbContext readDbContext)
    : IRequestHandler<GetDirectorQuery, DirectorDetailsDto>
{
    public async Task<DirectorDetailsDto> Handle(GetDirectorQuery query,
        CancellationToken cancellationToken)
    {
        var director = await readDbContext.Directors
            .AsNoTracking()
            .Include(x => x.DirectorPhoto)
            .ThenInclude(x => x.Photo)
            .SingleOrDefaultAsync(x => x.Id == query.DirectorId, cancellationToken)
            .NotNull(() => new DirectorNotFoundException(query.DirectorId));

        return director.AsDetailsDto();
    }
}