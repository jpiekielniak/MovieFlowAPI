using MovieFlow.Modules.Movies.Application.Movies.Queries.Get;
using MovieFlow.Modules.Movies.Application.Movies.Queries.Get.DTO;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Queries.GetMovieHandler;

internal sealed class GetMovieHandler(
    MoviesReadDbContext readDbContext
) : IRequestHandler<GetMovieQuery, MovieDetailsDto>
{
    public async Task<MovieDetailsDto> Handle(
        GetMovieQuery query,
        CancellationToken cancellationToken)
    {
        var movie = await readDbContext.Movies
            .AsNoTracking()
            .Include(x => x.Director)
            .Include(x => x.Genres)
            .SingleOrDefaultAsync(x => x.Id == query.MovieId, cancellationToken);

        return movie?.AsMovieDetailsDto();
    }
}