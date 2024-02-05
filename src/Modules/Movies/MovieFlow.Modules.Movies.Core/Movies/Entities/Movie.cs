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
    internal Rating Rating { get; private set; }
    internal ICollection<Genre> Genres { get;  set; }

    private Movie() // for EF
    {
    }

    private Movie(Title title, Description description,
        ReleaseYear releaseYear, Rating rating, EntityState entityState)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        ReleaseYear = releaseYear;
        Rating = rating;
        State = entityState;
    }

    public static Movie Create(string title, string description,
        int releaseYear, double rating)
        => new(title, description, releaseYear, rating, EntityState.Added);

    internal void ChangeInformation(Title title, Description description,
        ReleaseYear releaseYear, Rating rating)
    {
        Title = title;
        Description = description;
        ReleaseYear = releaseYear;
        Rating = rating;
        State = EntityState.Modified;
    }
}