using MovieFlow.Modules.Movies.Application.Movies.Queries.GetMovie;
using MovieFlow.Modules.Movies.Application.Movies.Queries.GetMovie.DTO;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Queries.GetMovieHandler;

internal sealed class GetMovieHandler(MoviesReadDbContext readDbContext)
    : IRequestHandler<GetMovieQuery, MovieDetailsDto>
{
    public async Task<MovieDetailsDto> Handle(GetMovieQuery query,
        CancellationToken cancellationToken)
    {
        var movie = await readDbContext.Movies
            .AsNoTracking()
            .Include(x => x.Reviews)
            .Include(x => x.Director)
                .ThenInclude(x => x.Photos)
            .Include(x => x.Genres)
            .Include(x => x.Photos)
            .SingleOrDefaultAsync(x => x.Id == query.MovieId, cancellationToken);

        return movie?.AsMovieDetailsDto();
    }
}