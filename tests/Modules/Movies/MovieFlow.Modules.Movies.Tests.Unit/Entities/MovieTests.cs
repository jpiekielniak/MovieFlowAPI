using MovieFlow.Modules.Movies.Core.Movies.Entities;
using Shouldly;
using Xunit;

namespace MovieFlow.Modules.Movies.Tests.Unit.Entities;

public class MovieTests
{
    private static Movie Act(string title, string description, int releaseYear, Director director, List<Genre> genres)
        => Movie.Create(title, description, releaseYear, director, genres);

    private static void Act(Movie movie, string title, string description, int releaseYear) =>
        movie.ChangeInformation(title, description, releaseYear);

    [Fact]
    public void given_valid_movie_should_succeed()
    {
        //Arrange
        var director = CreateDirector();
        var genre = CreateGenre();

        //Act
        var movie = Act("Kubuś Puchatek", "Test description", 2024, director, [genre]);

        //Assert
        movie.ShouldBeOfType<Movie>();
        movie.ShouldNotBeNull();
    }

    [Fact]
    public void given_invalid_title_should_fail()
    {
        //Arrange
        var director = CreateDirector();
        var genre = CreateGenre();

        //Act
        var exception = Record.Exception(() => Act(null, "Test description", 2024, director, [genre]));

        //Assert
        exception.ShouldNotBeNull();
    }

    [Fact]
    public void given_release_year_with_feature_should_fail()
    {
        //Arrange
        var director = CreateDirector();
        var genre = CreateGenre();

        //Act
        var exception = Record.Exception(() =>
            Act("Kubuś Puchatek", "Test description", DateTime.Now.AddYears(3).Year, director, [genre]));

        //Assert
        exception.ShouldNotBeNull();
    }

    [Fact]
    public void given_null_genres_should_fail()
    {
        //Arrange
        var director = CreateDirector();

        //Act
        var exception = Record.Exception(() =>
            Act("Kubuś Puchatek", "Test description", 2024, director, null));

        //Assert
        exception.ShouldNotBeNull();
    }

    [Fact]
    public void given_null_director_should_fail()
    {
        //Arrange
        var genre = CreateGenre();

        //Act
        var exception = Record.Exception(() =>
            Act("Kubuś Puchatek", "Test description", 2024, null, [genre]));

        //Assert
        exception.ShouldNotBeNull();
    }

    [Fact]
    public void given_valid_information_to_change_should_succeed()
    {
        //Arrange
        var director = CreateDirector();
        var genre = CreateGenre();
        var movie = Act("Kubuś Puchatek", "Test description", 2024, director, [genre]);

        //Act
        Act(movie, "Kubuś Puchatek 2", "Test description 2", 2023);

        //Assert
        movie.Title.Value.ShouldBe("Kubuś Puchatek 2");
        movie.Description.Value.ShouldBe("Test description 2");
        movie.ReleaseYear.Value.ShouldBe(2023);
    }

    [Fact]
    public void given_valid_photo_to_movie_should_succeed()
    {
        //Arrange
        var director = CreateDirector();
        var genre = CreateGenre();
        var movie = Act("Kubuś Puchatek", "Test description", 2024, director, [genre]);
        var photo = CreatePhoto();

        //Act
        movie.AddPhoto(photo);

        //Assert
        movie.Photos.ShouldNotBeEmpty();
        movie.Photos.Count.ShouldBe(1);
    }

    [Fact]
    public void given_null_photo_to_movie_should_fail()
    {
        //Arrange
        var director = CreateDirector();
        var genre = CreateGenre();
        var movie = Act("Kubuś Puchatek", "Test description", 2024, director, [genre]);

        //Act
        var exception = Record.Exception(() => movie.AddPhoto(null));

        //Assert
        exception.ShouldNotBeNull();
        movie.Photos.ShouldBeEmpty();
        movie.Photos.Count.ShouldBe(0);
    }

    [Fact]
    public void given_valid_movie_without_reviews_should_rating_equals_zero()
    {
        //Arrange
        var director = CreateDirector();
        var genre = CreateGenre();

        //Act
        var movie = Act("Kubuś Puchatek", "Test description", 2024, director, [genre]);

        //Assert
       movie.Rating.ShouldBe(0.0);
       movie.Rating.ShouldBeOfType<double>();
    }
    
    private static Director CreateDirector() => Director.Create("John", "Doe", new DateTime(1970, 04, 25), "USA");
    private static Genre CreateGenre() => Genre.Create("Genre");
    private static Photo CreatePhoto() => Photo.Create("Photo", "www.movieflow.com/photos/photo", "Photo", "");
}