namespace MovieFlow.Modules.Movies.Core.Movies.Entities;

internal sealed class Like
{
    public Guid Id { get; init; }
    internal bool IsPositive { get; set; }
    internal Guid ReviewId { get; set; }
    internal Review Review { get; set; }
    internal Guid UserId { get; set; }

    private Like() 
    {
    }

    private Like(Review review, Guid userId, bool isPositive)
    {
        Id = Guid.NewGuid();
        Review = review;
        UserId = userId;
        IsPositive = isPositive;
    }


    public static Like Create(Review review, Guid userId, bool isPositive)
        => new(review, userId, isPositive);
}