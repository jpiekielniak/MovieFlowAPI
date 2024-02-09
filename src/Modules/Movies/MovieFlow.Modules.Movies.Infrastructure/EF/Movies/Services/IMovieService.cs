using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Services;

internal interface IMovieService
{
    IQueryable<MovieReadModel> FilterByTitle(IQueryable<MovieReadModel> movies, string title);

    IQueryable<MovieReadModel> FilterByGenre(IQueryable<MovieReadModel> movies, string genre);

    IQueryable<MovieReadModel> FilterByReleaseYear(IQueryable<MovieReadModel> movies, int releaseYear);

    IQueryable<MovieReadModel> FilterByDirector(IQueryable<MovieReadModel> movies, string director);
}