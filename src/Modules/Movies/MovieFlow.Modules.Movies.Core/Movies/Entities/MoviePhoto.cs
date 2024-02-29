namespace MovieFlow.Modules.Movies.Core.Movies.Entities;

internal class MoviePhoto
{
    public Guid Id { get; private set; }
    public Guid MovieId { get; private set; }
    public Movie Movie { get; private set; }
    public Guid PhotoId { get; private set; }
    public Photo Photo { get; private set; }
}