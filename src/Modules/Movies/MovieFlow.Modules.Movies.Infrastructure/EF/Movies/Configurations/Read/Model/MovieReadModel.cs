namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

internal sealed class MovieReadModel
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public int ReleaseYear { get; init; }
    public double Rating { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset? UpdatedAt { get; init; }
}