using MovieFlow.Modules.Movies.Core.Movies.Entities;
using Shouldly;
using Xunit;
using static MovieFlow.Modules.Movies.Tests.Unit.Entities.Extensions.Extensions;

namespace MovieFlow.Modules.Movies.Tests.Unit.Entities;

public class ReviewTests
{
    [Fact]
    public void given_valid_review_should_succeed()
    {
        //Arrange
        const string title = "title";
        const string content = "content";
        const int rating = 5;
        var director = GetValidDirector();
        var genre = CreateGenre();
        var movie = GetValidMovie(director, genre);

        //Act
        var review = Review.Create(title, content, rating, movie, Guid.NewGuid());

        //Assert
        review.ShouldNotBeNull();
        review.ShouldBeOfType<Review>();
        review.Id.ShouldBeAssignableTo<Guid>();
        review.Id.ShouldNotBe(Guid.Empty);
    }
    
    [Fact]
    public void given_valid_review_when_change_review_should_succeed()
    {
        //Arrange
        var review = CreateReview();
        const string newTitle = "new title";
        const string newContent = "new content";
        const double newRating = 4.5;

        //Act
        review.Change(newTitle, newContent, newRating);

        //Assert
        review.Title.Value.ShouldBe(newTitle);
        review.Content.Value.ShouldBe(newContent);
        review.Rating.Value.ShouldBe(newRating);
    }
}