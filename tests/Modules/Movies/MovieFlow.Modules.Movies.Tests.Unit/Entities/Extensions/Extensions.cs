using MovieFlow.Modules.Movies.Core.Movies.Entities;

namespace MovieFlow.Modules.Movies.Tests.Unit.Entities.Extensions;

internal static class Extensions
{
    public static Director CreateDirector() => Director.Create("John", "Doe", new DateTime(1970, 04, 25), "USA");
    public static Genre CreateGenre() => Genre.Create("Genre");
    public static Photo CreatePhoto() => Photo.Create("Photo", "www.movieflow.com/photos/photo", "Photo", "");

    public static Movie GetValidMovie(Director director, Genre genre)
        => Movie.Create("Kubuś Puchatek", "Test description", 2024, director, [genre]);

    public static Director GetValidDirector() => Director.Create("John", "Doe", new DateTime(1970, 4, 20), "USA");

    public static Review CreateReview()
    {
        var genre = CreateGenre();
        var director = CreateDirector();
        var movie = GetValidMovie(director, genre);
        
        return Review.Create("Title", "content", 5.0, movie, Guid.NewGuid());
    }
}