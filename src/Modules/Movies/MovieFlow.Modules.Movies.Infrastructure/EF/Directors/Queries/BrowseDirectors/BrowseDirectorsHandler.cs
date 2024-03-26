using MovieFlow.Modules.Movies.Application.Directors.Queries.BrowseDirectors;
using MovieFlow.Modules.Movies.Application.Shared.DTO;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;
using MovieFlow.Modules.Movies.Infrastructure.EF.Directors.Services;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Directors.Queries.BrowseDirectors;

internal sealed class BrowseDirectorsHandler(
    MoviesReadDbContext readDbContext,
    IDirectorService directorService)
    : IRequestHandler<BrowseDirectorsQuery, List<DirectorDto>>
{
    public async Task<List<DirectorDto>> Handle(BrowseDirectorsQuery query,
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
            .Select(x => x.AsDto())
            .ToListAsync(cancellationToken);
    }
}