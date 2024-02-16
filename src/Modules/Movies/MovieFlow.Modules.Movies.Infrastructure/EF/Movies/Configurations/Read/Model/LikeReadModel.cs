namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

internal sealed class LikeReadModel
{
    public Guid Id { get; init; }
    public bool IsPositive { get; init; }
    public Guid ReviewId { get; init; }
    public Guid UserId { get; init; }
}