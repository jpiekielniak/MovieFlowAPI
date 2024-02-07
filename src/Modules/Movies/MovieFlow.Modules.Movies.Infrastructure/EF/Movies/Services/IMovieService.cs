using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Services;

internal interface IMovieService
{
    Task<IQueryable<MovieReadModel>> FilterByTitleAsync(
        IQueryable<MovieReadModel> movies, string title, CancellationToken cancellationToken);
    
    Task<IQueryable<MovieReadModel>> FilterByGenreAsync(IQueryable<MovieReadModel> movies, string genre,
        CancellationToken cancellationToken);
    
    Task<IQueryable<MovieReadModel>> FilterByReleaseYearAsync(IQueryable<MovieReadModel> movies, int releaseYear,
        CancellationToken cancellationToken);
}