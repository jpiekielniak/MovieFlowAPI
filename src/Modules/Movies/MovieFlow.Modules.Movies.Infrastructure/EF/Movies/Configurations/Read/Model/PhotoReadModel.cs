namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

internal sealed class PhotoReadModel
{
    public Guid Id { get; init; }
    public string FileName { get; init; }
    public string Url { get; init; }
    public string Alt { get; init; }
    public string ContentType { get; init; }
    public Guid? MovieId { get; init; }
    public MovieReadModel Movie { get; init; }
    public Guid? DirectorId { get; init; }
    public DirectorReadModel Director { get; init; }
}