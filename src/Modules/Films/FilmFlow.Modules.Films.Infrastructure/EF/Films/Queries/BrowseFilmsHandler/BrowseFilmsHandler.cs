using FilmFlow.Modules.Films.Application.Films.Queries.Browse;
using FilmFlow.Modules.Films.Application.Films.Queries.Browse.DTO;
using FilmFlow.Modules.Films.Infrastructure.EF.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FilmFlow.Modules.Films.Infrastructure.EF.Films.Queries.BrowseFilmsHandler;

internal sealed class BrowseFilmsHandler(
    FilmsReadDbContext readDbContext)
    : IRequestHandler<BrowseFilmsQuery, List<FilmDto>>
{
    public async Task<List<FilmDto>> Handle(BrowseFilmsQuery query,
        CancellationToken cancellationToken)
    {
        var films = readDbContext
            .Films
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Title))
        {
            var search = $"%{query.Title}%";
            films = films.Where(
                f => Microsoft.EntityFrameworkCore.EF.Functions.ILike(
                    f.Title, search));
        }

        if (query.ReleaseYear is > 0)
            films = films.Where(f => f.ReleaseYear == query.ReleaseYear);

        return await films
            .AsNoTracking()
            .Select(x => x.AsFilmDto())
            .ToListAsync(cancellationToken);
    }
}