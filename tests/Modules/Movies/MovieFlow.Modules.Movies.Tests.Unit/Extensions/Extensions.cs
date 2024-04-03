using MovieFlow.Modules.Movies.Core.Movies.Entities;

namespace MovieFlow.Modules.Movies.Tests.Unit.Extensions;

internal static class Extensions
{
    public static Director CreateDirector() => Director.Create("John", "Doe", new DateTime(1970, 04, 25), "USA");
    public static Genre CreateGenre() => Genre.Create("Genre");
    public static Photo CreatePhoto() => Photo.Create("Photo", "www.movieflow.com/photos/photo", "Photo", "");

    public static Movie GetValidMovie()
        => Movie.Create("Kubuś Puchatek", "Test description", 2024, CreateDirector(), [CreateGenre()]);

    public static Director GetValidDirector() => Director.Create("John", "Doe", new DateTime(1970, 4, 20), "USA");

    public static Review CreateReview()
        => Review.Create("Title", "content", 5.0, GetValidMovie(), Guid.NewGuid());

    public static FormFile CreateFormFile()
    {
        var memoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(string.Empty));
        var formFile = new FormFile(memoryStream, 0, memoryStream.Length, "Photo", "Photo.jpg")
        {
            Headers = new HeaderDictionary(),
            ContentType = string.Empty
        };

        return formFile;
    }
}