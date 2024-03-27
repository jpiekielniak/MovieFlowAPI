using MovieFlow.Modules.Movies.Core.Movies.Entities;
using static MovieFlow.Modules.Movies.Tests.Unit.Entities.Extensions.Extensions;

namespace MovieFlow.Modules.Movies.Tests.Unit.Entities;

public class LikeTests
{
    [Fact]
    public void given_valid_like_should_succeed()
    {
        // Arrange
        var review = CreateReview();
        var userId = Guid.NewGuid();
        const bool isPositive = true;

        // Act
        var like = Like.Create(review, userId, isPositive);

        // Assert
        like.ShouldNotBeNull();
        like.Review.ShouldBe(review);
        like.UserId.ShouldBe(userId);
        like.IsPositive.ShouldBe(isPositive);
    }
}
