namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

internal class DirectorPhotoReadModel
{
    public Guid Id { get; init; }
    public Guid DirectorId { get; init; }
    public DirectorReadModel Director { get; init; }
    public Guid PhotoId { get; init; }
    public PhotoReadModel Photo { get; init; }
}