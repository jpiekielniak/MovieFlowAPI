using MovieFlow.Modules.Movies.Application.Directors.Queries.GetMoviesForDirector;
using MovieFlow.Modules.Movies.Application.Directors.Queries.GetMoviesForDirector.DTO;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Directors;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Directors.Queries.GetMoviesForDirector;

internal sealed class GetMoviesForDirectorHandler(MoviesReadDbContext readDbContext)
    : IRequestHandler<GetMoviesForDirectorQuery, List<DirectorMovieDto>>
{
    public async Task<List<DirectorMovieDto>> Handle(GetMoviesForDirectorQuery query,
        CancellationToken cancellationToken)
    {
        var director = await readDbContext.Directors
            .AsNoTracking()
            .Include(d => d.Movies)
            .ThenInclude(x => x.Photos)
            .SingleOrDefaultAsync(d => d.Id == query.DirectorId, cancellationToken)
            .NotNull(() => new DirectorNotFoundException(query.DirectorId));

        return director.Movies
            .Select(x => x.AsDirectorMovieDto())
            .ToList();

    }
}