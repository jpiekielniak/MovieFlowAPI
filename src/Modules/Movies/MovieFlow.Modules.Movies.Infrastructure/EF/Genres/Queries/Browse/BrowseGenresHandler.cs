using MovieFlow.Modules.Movies.Application.Genres.Queries.Browse;
using MovieFlow.Modules.Movies.Application.Genres.Queries.Browse.DTO;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Genres.Queries.Browse;

internal sealed class BrowseGenresHandler(MoviesReadDbContext readDbContext)
    : IRequestHandler<BrowseGenresQuery, List<BrowseGenresDto>>
{
    public async Task<List<BrowseGenresDto>> Handle(BrowseGenresQuery request, 
        CancellationToken cancellationToken)
        => await readDbContext.Genres
            .AsNoTracking()
            .Select(x => new BrowseGenresDto(x.Id, x.Name))
            .ToListAsync(cancellationToken);
}