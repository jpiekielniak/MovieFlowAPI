using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Description;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.ReleaseYear;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Title;

namespace MovieFlow.Modules.Movies.Core.Movies.Entities;

internal sealed class Movie : Entity
{
    internal Title Title { get; private set; }
    internal Description Description { get; private set; }
    internal ReleaseYear ReleaseYear { get; private set; }
    internal Guid DirectorId { get; private set; }
    internal Director Director { get; private set; }
    internal double? Rating => Reviews.Any() ? Reviews.Average(x => x.Rating) : 0;
    internal List<Genre> Genres { get; private set; }
    internal List<Review> Reviews { get; private set; }
    internal ICollection<Photo> Photos { get; private set; }
    

    private Movie()
    {
    }

    private Movie(Title title, Description description,
        ReleaseYear releaseYear, Director director,
        List<Genre> genres, EntityState entityState)
    {
        Title = title;
        Description = description;
        ReleaseYear = releaseYear;
        Director = director ?? throw new DirectorCannotBeNullException();
        Genres = genres ?? throw new GenresCannotBeNullException();
        Reviews = [];
        Photos = [];
        State = entityState;
    }

    public static Movie Create(string title, string description,
        int releaseYear, Director director, List<Genre> genres)
        => new(title, description, releaseYear, director, genres, EntityState.Added);

    internal void ChangeInformation(Title title, Description description,
        ReleaseYear releaseYear)
    {
        Title = title;
        Description = description;
        ReleaseYear = releaseYear;
        State = EntityState.Modified;
    }

    internal void AddPhoto(Photo photo)
    => Photos.Add(photo ?? throw new PhotoCannotBeNullException());
}