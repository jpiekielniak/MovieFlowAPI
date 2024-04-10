using MovieFlow.Modules.Movies.Core.Movies.Entities;

namespace MovieFlow.Modules.Movies.Tests.Unit.Entities;

public class GenreTests
{
    [Theory]
    [MemberData(nameof(GetValidGenreName), MemberType = typeof(Extensions.Extensions))]
    public void given_valid_genre_should_succeed(string value)
    {
        //Act
        var genre = Genre.Create(value);
        
        //Assert
        genre.ShouldNotBeNull();
        genre.ShouldBeOfType<Genre>();
        genre.Id.ShouldBeAssignableTo<Guid>();
    }

    [Theory]
    [MemberData(nameof(GetInvalidGenreName))]
    public void given_invalid_genre_should_fail(string value)
    {
        //Act
        var exception = Record.Exception(() => Genre.Create(value));
        
        //Assert
        exception.ShouldNotBeNull();
    }

    public static IEnumerable<object[]> GetInvalidGenreName()
    {
        yield return [null];
        yield return [""];
        yield return [" "];
        yield return ["Drama!"];
        yield return ["123"];
        yield return ["aaa"];
    }
}