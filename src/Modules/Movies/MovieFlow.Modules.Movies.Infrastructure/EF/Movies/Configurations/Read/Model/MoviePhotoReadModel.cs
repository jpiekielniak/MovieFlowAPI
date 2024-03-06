namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

internal sealed class MoviePhotoReadModel
{
    public Guid Id { get; init; }
    public Guid MovieId { get; init; }
    public MovieReadModel Movie { get; init; }
    public Guid PhotoId { get; init; }
    public PhotoReadModel Photo { get; init; }
}