using MovieFlow.Shared.Abstractions.Kernel;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Description;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Rating;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.ReleaseYear;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Title;

namespace MovieFlow.Modules.Movies.Core.Movies.Entities;

internal sealed class Movie : Entity
{
    internal Title Title { get; private set; }
    internal Description Description { get; private set; }
    internal ReleaseYear ReleaseYear { get; private set; }
    internal Rating Rating => Reviews.Average(x => x.Rating);
    internal Guid DirectorId { get; private set; }
    internal Director Director { get; private set; }
    internal ICollection<Genre> Genres { get; set; }
    internal ICollection<Review> Reviews { get; set; }

    private Movie()
    {
    }

    private Movie(Title title, Description description,
        ReleaseYear releaseYear,
        Director director, ICollection<Genre> genres, EntityState entityState)
    {
        Title = title;
        Description = description;
        ReleaseYear = releaseYear;
        Director = director;
        Genres = genres;
        Reviews = new List<Review>();
        State = entityState;
    }

    public static Movie Create(string title, string description,
        int releaseYear, Director director, ICollection<Genre> genres)
        => new(title, description, releaseYear, director, genres, EntityState.Added);

    internal void ChangeInformation(Title title, Description description,
        ReleaseYear releaseYear)
    {
        Title = title;
        Description = description;
        ReleaseYear = releaseYear;
        State = EntityState.Modified;
    }
}