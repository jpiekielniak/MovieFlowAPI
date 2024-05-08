using MovieFlow.Modules.Movies.Application.Genres.Queries.BrowseGenres;
using MovieFlow.Modules.Movies.Application.Genres.Queries.BrowseGenres.DTO;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Genres.Queries.BrowseGenres;

internal sealed class BrowseGenresHandler(MoviesReadDbContext readDbContext)
    : IRequestHandler<BrowseGenresQuery, List<BrowseGenresDto>>
{
    public async Task<List<BrowseGenresDto>> Handle(BrowseGenresQuery query, 
        CancellationToken cancellationToken)
        => await readDbContext.Genres
            .AsNoTracking()
            .Select(x => new BrowseGenresDto(x.Id, x.Name))
            .ToListAsync(cancellationToken);
}