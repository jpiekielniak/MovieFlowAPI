using MovieFlow.Modules.Movies.Application.Directors.Queries.BrowseDirectors;
using MovieFlow.Modules.Movies.Application.Movies.Queries.BrowseMovies.DTO;
using MovieFlow.Modules.Movies.Application.Shared.DTO;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;
using MovieFlow.Modules.Movies.Infrastructure.EF.Directors.Services;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Directors.Queries.BrowseDirectors;

internal sealed class BrowseDirectorsHandler(
    MoviesReadDbContext readDbContext,
    IDirectorService directorService)
    : IRequestHandler<BrowseDirectorsQuery, List<BrowseDirectorDto>>
{
    public async Task<List<BrowseDirectorDto>> Handle(BrowseDirectorsQuery query,
        CancellationToken cancellationToken)
    {
        var directors = readDbContext.Directors
            .AsNoTracking()
            .Include(x => x.Photos)
            .AsQueryable();

        directors = directorService.FilterByName(directors, query.Name);
        directors = directorService.FilterByDateOfBirth(directors, query.DateOfBirth);
        directors = directorService.FilterByCountry(directors, query.Country);

        return await directors
            .Select(x => x.AsBrowseDto())
            .ToListAsync(cancellationToken);
    }
}