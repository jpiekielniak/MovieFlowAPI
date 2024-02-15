namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

internal class ReviewReadModel
{
    public Guid Id { get; }
    public string Title { get; }
    public string Content { get; }
    public uint PositiveLikes { get; }
    public uint NegativeLikes { get; }
    public MovieReadModel Movie { get; }
    public Guid UserId { get; }
}