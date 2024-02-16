
namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

internal class ReviewReadModel
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Content { get; init; }
    public double Rating { get; init; }
    public IReadOnlyCollection<LikeReadModel> Likes { get; }
    public int PositiveLikes => Likes.Count(x => x.IsPositive);
    public int NegativeLikes => Likes.Count(x => !x.IsPositive);
    public Guid MovieId { get; init; }
    public MovieReadModel Movie { get; init; }
    public Guid UserId { get; init; }
}