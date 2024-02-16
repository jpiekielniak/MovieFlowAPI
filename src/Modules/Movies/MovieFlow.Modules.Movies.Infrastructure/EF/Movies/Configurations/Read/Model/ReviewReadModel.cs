using MovieFlow.Modules.Movies.Core.Movies.Entities;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

internal class ReviewReadModel
{
    public Guid Id { get; }
    public string Title { get; }
    public string Content { get; }
    public IReadOnlyCollection<Like>? Likes { get; }
    public int PositiveLikes => Likes?.Count(x => x.IsPositive) ?? 0;
    public int NegativeLikes => Likes?.Count(x => !x.IsPositive) ?? 0;
    public MovieReadModel Movie { get; }
    public Guid UserId { get; }
}