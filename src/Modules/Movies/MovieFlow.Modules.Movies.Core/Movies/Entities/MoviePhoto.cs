namespace MovieFlow.Modules.Movies.Core.Movies.Entities;

internal class MoviePhoto
{
    public Guid Id { get; private set; }
    public Guid MovieId { get; private set; }
    public Movie Movie { get; private set; }
    public Guid PhotoId { get; private set; }
    public Photo Photo { get; private set; }

    private MoviePhoto()
    {
    }
    
    private MoviePhoto(Movie movie, Photo photo)
    {
        Id = Guid.NewGuid();
        Movie = movie;
        Photo = photo;
    }

    public static MoviePhoto Create(Movie movie, Photo photo) => new(movie, photo);
}
