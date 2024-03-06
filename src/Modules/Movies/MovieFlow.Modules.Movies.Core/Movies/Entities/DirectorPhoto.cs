namespace MovieFlow.Modules.Movies.Core.Movies.Entities;

internal class DirectorPhoto
{
    public Guid Id { get; private set; }
    public Guid DirectorId { get; private set; }
    public Director Director { get; private set; }
    public Guid PhotoId { get; private set; }
    public Photo Photo { get; private set; }

    private DirectorPhoto()
    {
    }

    private DirectorPhoto(Director director, Photo photo)
    {
        Id = Guid.NewGuid();
        Director = director;
        Photo = photo;
    }

    public static DirectorPhoto Create(Director director, Photo photo) => new(director, photo);
}