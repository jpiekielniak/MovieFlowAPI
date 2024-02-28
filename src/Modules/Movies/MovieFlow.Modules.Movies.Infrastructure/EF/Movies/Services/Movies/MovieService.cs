using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Services.Movies;

internal sealed class MovieService : IMovieService
{
    public IQueryable<MovieReadModel> FilterByTitle(IQueryable<MovieReadModel> movies, string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            return movies;

        var search = $"%{title}%";
        movies = movies.Where(
            f => Microsoft.EntityFrameworkCore.EF.Functions.ILike(
                f.Title, search));

        return movies;
    }

    public IQueryable<MovieReadModel> FilterByGenre(IQueryable<MovieReadModel> movies, string genre)
    {
        if (string.IsNullOrWhiteSpace(genre))
            return movies;

        var search = $"%{genre}%";
        movies = movies.Where(
            f => f.Genres.Any(g => Microsoft.EntityFrameworkCore.EF.Functions.ILike(
                g.Name, search)));

        return movies;
    }

    public IQueryable<MovieReadModel> FilterByReleaseYear(IQueryable<MovieReadModel> movies, int releaseYear)
        => releaseYear <= 0 ? movies : movies.Where(f => f.ReleaseYear == releaseYear);

    public IQueryable<MovieReadModel> FilterByDirector(IQueryable<MovieReadModel> movies, string director)
    {
        if (string.IsNullOrWhiteSpace(director))
            return movies;

        var search = $"%{director}%";

        return movies.Where(f =>
            Microsoft.EntityFrameworkCore.EF.Functions.ILike(
                f.Director.FirstName + " " + f.Director.LastName, search)
        );
    }
}