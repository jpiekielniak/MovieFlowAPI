using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Shared.Abstractions.Exceptions;
using Shouldly;
using Xunit;
using static MovieFlow.Modules.Movies.Tests.Unit.Entities.Extensions.Extensions;

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
        var movie = GetValidMovie(director, genre);

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
        const string description = "Test description";

        //Act
        var exception = Record.Exception(() => Act(null, description, 2024, director, [genre]));

        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeAssignableTo<MovieFlowException>();
    }

    [Fact]
    public void given_release_year_with_feature_should_fail()
    {
        //Arrange
        var director = CreateDirector();
        var genre = CreateGenre();
        const string title = "Kubuś Puchatek";
        const string description = "Test description";

        //Act
        var exception = Record.Exception(() => Act(title, description, DateTime.Now.AddYears(3).Year, director, [genre]));

        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeAssignableTo<MovieFlowException>();
    }

    [Fact]
    public void given_null_genres_should_fail()
    {
        //Arrange
        var director = CreateDirector();
        const string title = "Kubuś Puchatek";
        const string description = "Test description";
        const int releaseYear = 2023;

        //Act
        var exception = Record.Exception(() => Act(title, description, releaseYear, director, null));
        
        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeAssignableTo<MovieFlowException>();
    }

    [Fact]
    public void given_null_director_should_fail()
    {
        //Arrange
        var genre = CreateGenre();
        const string title = "Kubuś Puchatek";
        const string description = "Test description";
        const int releaseYear = 2023;

        //Act
        var exception = Record.Exception(() =>
            Act(title, description, releaseYear, null, [genre]));

        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeAssignableTo<MovieFlowException>();
    }

    [Fact]
    public void given_valid_information_to_change_should_succeed()
    {
        //Arrange
        var director = CreateDirector();
        var genre = CreateGenre();
        var movie = GetValidMovie(director, genre);
        const string title = "Kubuś Puchatek 2";
        const string description = "Test description 2";
        const int releaseYear = 2023;

        //Act
        Act(movie, title, description, releaseYear);

        //Assert
        movie.Title.Value.ShouldBe(title);
        movie.Description.Value.ShouldBe(description);
        movie.ReleaseYear.Value.ShouldBe(releaseYear);
    }


    [Fact]
    public void given_valid_photo_to_movie_should_succeed()
    {
        //Arrange
        var director = CreateDirector();
        var genre = CreateGenre();
        var movie = GetValidMovie(director, genre);
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
        var movie = GetValidMovie(director, genre);

        //Act
        var exception = Record.Exception(() => movie.AddPhoto(null));

        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeAssignableTo<MovieFlowException>();
        movie.Photos.ShouldBeEmpty();
        movie.Photos.Count.ShouldBe(0);
    }

    [Fact]
    public void given_valid_movie_without_reviews_should_rating_equals_zero()
    {
        //Arrange
        var director = CreateDirector();
        var genre = CreateGenre();
        const string title = "Kubuś Puchatek";
        const string description = "Test description";
        const int releaseYear = 2024;

        //Act
        var movie = Act(title, description, releaseYear, director, [genre]);

        //Assert
        movie.Rating.ShouldBe(0.0);
        movie.Rating.ShouldBeOfType<double>();
    }
}